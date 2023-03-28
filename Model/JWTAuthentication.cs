using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("jwt_authentication")]
public class JWTAuthentication : IJWTToken
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int jwtId { get; set; }
    [Required]
    public string jwtusername { get; set; }
    [Required]
    public string jwtpassword { get; set; }
    public char isValid { get; set; }
}