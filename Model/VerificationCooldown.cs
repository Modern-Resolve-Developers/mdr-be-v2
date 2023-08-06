using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;

[Table("verification_cooldown")]
public class VerificationCooldown : IVerificationCooldown
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public int resendCount { get; set; }
    public long cooldown { get; set; }
}