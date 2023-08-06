using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;

[Table("verification")]
public class Verification : IVerification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string email { get; set; }
    public string code { get; set; }
    public int resendCount { get; set; }
    public int isValid { get; set; }
    public string? type { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}