namespace danj_backend.Data;

public interface IFP
{
    int id { get; set; }
    string email { get; set; }
    int sentCounter { get; set; }
    string verificationCode { get; set; }
    char isValid { get; set; }
    DateTime expiry { get; set; }
    DateTime currentDate { get; set; }
    DateTime updatedDate { get; set; }
}