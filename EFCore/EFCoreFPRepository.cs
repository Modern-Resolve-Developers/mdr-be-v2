using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Helper;
using danj_backend.Model;
using danj_backend.Repository;
using danj_backend.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace danj_backend.EFCore;

public class EFCoreFPRepository<TEntity, TContext> : IFPRepository<TEntity>
where TEntity : class, IFP
where TContext : ApiDbContext
{
    private readonly TContext context;
    private readonly MailSettings _mailSettings;
    public EFCoreFPRepository(TContext context, IOptions<MailSettings> mailSettings)
    {
        this.context = context;
        this._mailSettings = mailSettings.Value;
    }

    public async Task<dynamic> findAnyFPVerified(string email)
    {
        DateTime expirationTime = DateTime.Now.AddHours(2);
        var code = verificationCodeGen.GenerateCode();
        var result = context.Set<TEntity>().Any(x => x.email == email);
        var checkIsValid = context.Set<TEntity>().Where(x => x.email == email).FirstOrDefault();
        if (result)
        {
            if (checkIsValid.isValid == Convert.ToChar("1"))
            {
                if (checkIsValid.sentCounter != 3)
                {
                    checkIsValid.sentCounter = checkIsValid.sentCounter + 1;
                    checkIsValid.verificationCode = code;
                    checkIsValid.expiry = expirationTime;
                    await SendEmailForgotPassword(email, code);
                    await context.SaveChangesAsync();
                    return "update_fp";
                }
                else
                {
                    
                    checkIsValid.isValid = Convert.ToChar("0");
                    await context.SaveChangesAsync();
                    return "max_3";
                }
            }
            else
            {
                /*
                 * Digital Resolve Organization Property
                 * Another API Call for resetting the sent Counter to 0 after the timeout from frontend.
                 */
                FP fp = new FP();
                fp.email = email;
                fp.expiry = expirationTime;
                fp.sentCounter = fp.sentCounter + 1;
                fp.verificationCode = code;
                fp.isValid = Convert.ToChar("1");
                fp.currentDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
                fp.updatedDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
                context.Fps.Add(fp);
                await context.SaveChangesAsync();
                await SendEmailForgotPassword(email, code);
                return "reset";
            }
        }
        else
        {
            FP fp = new FP();
            fp.email = email;
            fp.expiry = expirationTime;
            fp.sentCounter = fp.sentCounter + 1;
            fp.verificationCode = code;
            fp.isValid = Convert.ToChar("1");
            fp.currentDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
            fp.updatedDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
            context.Fps.Add(fp);
            await context.SaveChangesAsync();
            await SendEmailForgotPassword(email, code);
            return "success";
        }
    }

    public async Task SendEmailForgotPassword(string requestEmail, string code)
    {
        string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\emailTemplate.html";
        StreamReader str = new StreamReader(FilePath);
        string MailText = str.ReadToEnd();
        str.Close();
        MailText = MailText.Replace("[username]", "User").Replace("[email]", requestEmail).Replace("[verificationCode]", code);
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(requestEmail));
        email.Subject = $"Welcome {requestEmail}";
        var builder = new BodyBuilder();
        builder.HtmlBody = MailText;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }

    public async Task<dynamic> CheckVerificationCodeEntry(string code, string email)
    {
        var codeChecker = context.Set<TEntity>().Any(x => x.verificationCode == code);
        var fpEntityAll = context.Set<TEntity>().Where(x => x.email == email).FirstOrDefault();
        if (DateTime.Now > fpEntityAll.expiry)
        {
            /*
             * Verification code has been expired, client side must request another verification code from the backend
             */
            FP fp = new FP();
            fp.isValid = Convert.ToChar("0");
            await context.SaveChangesAsync();
            return "expired";
        }
        else
        {
            if (codeChecker)
            {
                FP fp = new FP();
                fp.isValid = Convert.ToChar("0");
                await context.SaveChangesAsync();
                return "verified";
            }
            else
            {
                return "invalid_code";
            }
        }
    }
}