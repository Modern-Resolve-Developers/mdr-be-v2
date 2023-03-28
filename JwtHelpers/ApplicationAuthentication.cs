using Microsoft.AspNetCore.Identity;

namespace danj_backend.JwtHelpers;

public class ApplicationAuthentication : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}