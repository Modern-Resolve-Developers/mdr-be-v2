namespace danj_backend.Data
{
    public interface IAuthHistory
    {
        int authId { get; set; }
        int userId { get; set; }
        string savedAuth { get; set; }
        char isValid { get; set; }
        DateTime created_at { get; set; }
        DateTime updated_at { get; set; }
        string preserve_data { get; set; }
    }
}
