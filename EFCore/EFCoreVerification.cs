using System.Dynamic;
using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Helper;
using danj_backend.Helper.CodeGenerator;
using danj_backend.Model;
using danj_backend.Repository;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;

namespace danj_backend.EFCore;

public abstract class EFCoreVerification<TEntity, TContext> : IVerificationRepository<TEntity>
where TEntity : class, IVerification
where TContext : ApiDbContext
{
    private readonly TContext context;
    private readonly MailSettings _mailSettings;

    public EFCoreVerification(TContext context, IOptions<MailSettings> mailSettings)
    {
        this.context = context;
        this._mailSettings = mailSettings.Value;
    }
    public async Task<dynamic> SMSVerificationDataManagement(TEntity entity, VerificationProps verificationProps)
    {
        var sentCount = await context.Set<TEntity>().Where(x => x.email == entity.email && x.isValid == 1)
            .FirstOrDefaultAsync();
        var verificationProfile = await context.Set<TEntity>().AnyAsync(x => x.email == entity.email && x.isValid == 1);
        var checkIfHasResentCode = await context.Set<TEntity>()
            .AnyAsync(x => x.email == entity.email && x.isValid == 1);
        if (entity.type == "email")
        {
            if (checkIfHasResentCode)
            {
                await SMSResendVerificationCode("email", entity.email);
                return 200;
            }
            else
            {
                if (verificationProfile)
                {
                    if (sentCount.resendCount >= 3)
                    {
                        return "max_sent_use_latest";
                    }
                    else
                    {
                        entity.code = GenerateVerificationCode.GenerateCode();
                        entity.isValid = 1;
                        entity.resendCount = sentCount.resendCount + 1;
                        entity.createdAt = DateTime.Today;
                        entity.updatedAt = DateTime.Today;
                        SendEmailSMTPWithCode(entity.email, entity.code, "Kindly use this code to verify your account");
                        await context.Set<TEntity>().AddAsync(entity);
                        await context.SaveChangesAsync();
                        return 200;
                    }
                }
                else
                {
                    entity.code = GenerateVerificationCode.GenerateCode();
                    entity.isValid = 1;
                    entity.resendCount = 1;
                    entity.createdAt = DateTime.Today;
                    entity.updatedAt = DateTime.Today;
                    SendEmailSMTPWithCode(entity.email, entity.code, "Kindly use this code to verify your account");
                    await context.Set<TEntity>().AddAsync(entity);
                    await context.SaveChangesAsync();
                    return 200;
                }
            }
        }
        else
        {
            return "sms";
        }
    }

    public async Task<dynamic> SMSCheckVerificationCode(string code, string email, string? type = "account_activation")
    {
        var verifyCode =
            await context.Set<TEntity>().AnyAsync(x => x.code == code && x.email == email && x.isValid == 1);
        var foundVerified = await context.Set<TEntity>()
            .Where(x => x.code == code && x.email == email && x.isValid == 1).FirstOrDefaultAsync();
        /* Boolean below is for account activation */
        var IsAccountByEmailExists =
            await context.Users.AnyAsync(x => x.email == email && x.verified == Convert.ToChar("0"));
        var foundAccountByEmail = await context.Users.Where(x => x.email == email && x.verified == Convert.ToChar("0"))
            .FirstOrDefaultAsync();
        if (verifyCode)
        {
            if (type == "account_activation")
            {
                foundVerified.isValid = 0;
                await context.SaveChangesAsync();
                return 200;
            }
            else
            {
                return 403;
            }
        }
        else
        {
            return 402;
        }
    }

    public async Task<dynamic> SMSResendVerificationCode(string type, string email)
    {
        var sentCount = await context.Set<TEntity>()
            .Where(x => x.email == email && x.isValid == 1).FirstOrDefaultAsync();
        var matchSentCountWithCooldown = await context.Set<VerificationCooldown>()
            .AnyAsync(x => x.resendCount == sentCount.resendCount);
        
        dynamic dynobj = new ExpandoObject();
        if (type == "email")
        {
            if (matchSentCountWithCooldown)
            {
                var findCooldown = await context.Set<VerificationCooldown>()
                    .Where(x => x.resendCount == sentCount.resendCount).FirstOrDefaultAsync();
                var code = GenerateVerificationCode.GenerateCode();
                sentCount.code = code;
                sentCount.resendCount = sentCount.resendCount + 1;
                sentCount.createdAt = DateTime.Today;
                SendEmailSMTPWithCode(
                    email,
                    code,
                    "Kindly use this code to verify your account"
                );
                await context.SaveChangesAsync();
                dynobj.cooldown = findCooldown.cooldown;
                dynobj.status = 401;
                return dynobj;
            }
            else
            {
                if (sentCount.resendCount >= 5)
                {
                    var code = GenerateVerificationCode.GenerateCode();
                    
                    return 400;
                }
                else
                {
                    var code = GenerateVerificationCode.GenerateCode();
                    sentCount.code = code;
                    sentCount.resendCount = sentCount.resendCount + 1;
                    sentCount.createdAt = DateTime.Today;
                    SendEmailSMTPWithCode(
                        email,
                        code,
                        "Kindly use this code to verify your account"
                    );
                    await context.SaveChangesAsync();
                    return 200;
                }
            }
        }
        else
        {
            return "sms-provider";
        }
    }

    public async Task SendEmailSMTPWithCode(string email, string code, string? body)
    {
        string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\emailTemplate.html";
        StreamReader str = new StreamReader(FilePath);
        string MailText = str.ReadToEnd();
        str.Close();
        MailText = MailText.Replace("[username]", "User").Replace("[email]", email).Replace("[verificationCode]", code)
            .Replace("[body]", body);
        var mail = new MimeMessage();
        mail.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        mail.To.Add(MailboxAddress.Parse(email));
        mail.Subject = $"Welcome {email}";
        var builder = new BodyBuilder();
        builder.HtmlBody = MailText;
        mail.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(mail);
        smtp.Disconnect(true);
    }

    public async Task SendWelcomeEmailSMTPWithoutCode(string email, string? body)
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> PostNewVerificationCooldowns(VerificationCooldown verificationCooldown)
    {
        var checkverificationEdition = await context.Set<VerificationCooldown>()
            .AnyAsync(x => x.resendCount == verificationCooldown.resendCount);
        VerificationCooldown vc = new VerificationCooldown();
        if (checkverificationEdition)
        {
            return 501;
        }
        else
        {
            vc.resendCount = verificationCooldown.resendCount;
            vc.cooldown = verificationCooldown.cooldown;
            await context.Set<VerificationCooldown>().AddAsync(vc);
            await context.SaveChangesAsync();
            return 200;
        }
    }

    public async Task<dynamic> CheckVerificationCountsWhenLoad(string email)
    {
        var selectedResentCounts = await context.Set<TEntity>()
            .Where(x => x.email == email && x.isValid == 1).FirstOrDefaultAsync();
        if (selectedResentCounts != null)
        {
            return selectedResentCounts.resendCount;
        }
        else
        {
            return 400;
        }
    }

    public async Task<dynamic> CheckVerificationAfter24Hours(string email)
    {
        var entity = await context.Set<TEntity>()
            .Where(x => x.email == email && x.isValid == 1).FirstOrDefaultAsync();
        if (entity != null)
        {
            TimeSpan timeDifference = DateTime.Now - entity.createdAt;
            if (timeDifference.TotalHours >= 24)
            {
                entity.isValid = 0;
                await context.SaveChangesAsync();
                return 200;
            }
            else
            {
                return 400;
            }
        }
        else
        {
            return 400;
        }
    }
}