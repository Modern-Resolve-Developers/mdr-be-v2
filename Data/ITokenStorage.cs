namespace danj_backend.Data;

public interface ITokenStorage
{
    int id { get; set; }
    string email { get; set; }
    string AccessToken { get; set; }
    string RefreshToken { get; set; }
    int isActive { get; set; }
    DateTime createdAt { get; set; }
}