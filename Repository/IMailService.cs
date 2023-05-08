using danj_backend.Helper;

namespace danj_backend.Repository;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
    
}