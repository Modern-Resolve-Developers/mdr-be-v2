﻿using danj_backend.Data;
using danj_backend.Helper;

namespace danj_backend.Repository;

public interface IVerificationRepository<T> where T : class, IVerification
{
    public Task<dynamic> SMSVerificationDataManagement(T entity, VerificationProps verificationProps);
    public Task<dynamic> SMSCheckVerificationCode(string code, string email, string? type = "account_activation");
    public Task<dynamic> SMSResendVerificationCode(string type, string email);
    public Task SendEmailSMTPWithCode(string email, string code, string? body);
    public Task SendWelcomeEmailSMTPWithoutCode(string email, string? body);
}