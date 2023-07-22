namespace danj_backend.Data;

public interface ISettings
{
    int id { get; set; }
    char dynamicDashboardEnabled { get; set; }
    string settingsType { get; set; }
    DateTime createdAt { get; set; }
    DateTime updatedAt { get; set; }
}