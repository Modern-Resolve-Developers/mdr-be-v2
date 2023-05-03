using danj_backend.Data;
using danj_backend.Helper;

namespace danj_backend.Repository;

public interface IFPRepository<T> where T : class, IFP
{
    public Task<dynamic> findAnyFPVerified(string email);
    Task SendEmailForgotPassword(string requestEmail, string code);
    Task<dynamic> CheckVerificationCodeEntry(string code, string email);
}