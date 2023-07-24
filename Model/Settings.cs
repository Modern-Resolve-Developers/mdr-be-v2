using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("dgr_settings")]
public class Settings : ISettings
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public char dynamicDashboardEnabled { get; set; }
    [Required]
    public string settingsType { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}