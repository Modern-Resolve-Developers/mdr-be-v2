namespace danj_backend.Data;

public interface IDeviceInformation
{
    int id { get; set; }
    Guid? deviceId { get; set; }
    string deviceInfoStringify { get; set; }
    string email { get; set; }
    int isActive { get; set; }
    string? deviceType { get; set; }
    string? deviceStatus { get; set; }
    int? request { get; set; }
    int isApproved { get; set; }
    DateTime createdAt { get; set; }
}