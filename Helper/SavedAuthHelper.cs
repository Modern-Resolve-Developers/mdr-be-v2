namespace danj_backend.Helper
{
    public class SavedAuthHelper
    {
        public string savedAuth { get; set; }
        public int userId {  get; set; }

        public SavedAuthHelper(string savedAuth, int userId)
        {
            this.savedAuth = savedAuth;
            this.userId = userId;
        }
    }
}