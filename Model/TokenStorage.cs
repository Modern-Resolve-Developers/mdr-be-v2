using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("token_storage")]
public class TokenStorage : ITokenStorage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [Required(ErrorMessage = "email is required.")]
    public string email { get; set; }
    [Required(ErrorMessage = "provide access token.")]
    public string AccessToken { get; set; }
    [Required(ErrorMessage = "provide refresh token.")]
    public string RefreshToken { get; set; }
    public int isActive { get; set; }
    public DateTime createdAt { get; set; }
}