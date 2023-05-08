namespace danj_backend.Helper;

public class FPRequest
{
    public string ToEmail { get; set; }
    public string? UserName { get; set; }
    public string? VerificationCode { get; set; }
    public DateTime? expiry { get; set; }
}