using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("fp_verifier")]
public class FP : IFP
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string email { get; set; }
    public int sentCounter { get; set; }
    public string verificationCode { get; set; }
    public char isValid { get; set; }
    public DateTime expiry { get; set; }
    public DateTime currentDate { get; set; }
    public DateTime updatedDate { get; set; }
}