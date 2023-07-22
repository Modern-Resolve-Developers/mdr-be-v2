using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("jitsi_joined")]
public class JitsiJoinedPersons : IJitsiJoinedPersons
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int roomId { get; set; }
    public string name { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}