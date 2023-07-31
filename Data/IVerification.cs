namespace danj_backend.Data;

public interface IVerification
{
    int id { get; set; }
    string email { get; set; }
    string code { get; set; }
    int resendCount { get; set; }
    int isValid { get; set; }
    string? type { get; set; }
    DateTime createdAt { get; set; }
    DateTime updatedAt { get; set; }
}