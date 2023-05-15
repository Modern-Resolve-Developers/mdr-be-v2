namespace danj_backend.Data;

public interface IJitsiJoinedPersons
{
    int Id { get; set; }
    int roomId { get; set; }
    string name { get; set; }
    DateTime createdAt { get; set; }
    DateTime updatedAt { get; set; }
}