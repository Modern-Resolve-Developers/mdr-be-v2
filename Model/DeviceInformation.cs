using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;

[Table("device_information")]
public class DeviceInformation : IDeviceInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public Guid? deviceId { get; set; }
    public string deviceInfoStringify { get; set; }
    public string email { get; set; }
    public int isActive { get; set; }
    public string? deviceType { get; set; }
    public string? deviceStatus { get; set; }
    public int? request { get; set; }
    public int isApproved { get; set; }
    public DateTime createdAt { get; set; }
}