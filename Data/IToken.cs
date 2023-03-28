namespace danj_backend.Data
{
    public interface IToken
    {
        int tokenId { get; set; }
        int userId { get; set; }
        string token { get; set; }
        char isExpired { get; set; }
        char isValid { get; set; }
        DateTime created_at { get; set; }
        DateTime updated_at { get; set; }
        DateTime expiration { get; set; }
    }
}
