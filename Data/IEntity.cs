namespace danj_backend.Data
{
    public interface IEntity
    {
        int Id { get; set; }
        string email { get; set; }
        string phoneNumber { get; set; }
        string password { get; set; }
        string firstname { get; set; }
        string middlename { get; set; }
        string lastname { get; set; }
        string imgurl { get; set; }
        char isstatus { get; set; }
        char verified { get; set; }
        int accountIsLoggedIn { get; set; }
        DateTime created_at { get; set; }
        DateTime updated_at { get; set; }
        int userType { get; set; }
    }
}