namespace danj_backend.Data;

public interface IProdCategFeatures
{
    int Id { get; set; }
    string label { get; set; }
    string value { get; set; }
    string type { get; set; }
}