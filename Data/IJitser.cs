namespace danj_backend.Data;

public interface IJitser
{
    int id { get; set; }
    string username { get; set; }
    string roomName { get; set; }
    string roomPassword { get; set; }
    string roomUrl { get; set; }
    char isPrivate { get; set; }
    char roomStatus { get; set; }
    string? createdBy { get; set; }
    DateTime createdAt { get; set; }
    DateTime updatedAt { get; set; }
}