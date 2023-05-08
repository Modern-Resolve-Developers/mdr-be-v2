using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("dg_jitser_meet")]
public class Jitser: IJitser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string username { get; set; }
    public string roomName { get; set; }
    public string roomPassword { get; set; }
    public char isPrivate { get; set; }
    public char roomStatus { get; set; }
    public string createdBy { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string roomUrl { get; set; }
}