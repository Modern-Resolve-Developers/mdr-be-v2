namespace danj_backend.Data
{
    public interface IDynamicRouting
    {
        int id { get; set; }
        int access_level { get; set; }
        Guid requestId { get; set; }
        string ToWhomRoute { get; set; }
        string exactPath { get; set; }
        DateTime created_at { get; set; }
    }
}