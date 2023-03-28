using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace danj_backend.Model;

[Table("token_model")]
public class TokenModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}