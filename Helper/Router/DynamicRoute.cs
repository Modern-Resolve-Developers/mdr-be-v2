namespace danj_backend.Helper.Router;

public class DynamicRoute
{
    public int id { get; set; }
    public int access_level { get; set; }
    public Guid? requestId { get; set; }
    public string ToWhomRoute { get; set; }
    public string exactPath { get; set; }
    public DateTime created_at { get; set; }
}