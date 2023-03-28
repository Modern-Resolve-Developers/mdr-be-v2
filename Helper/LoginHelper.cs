
namespace danj_backend.Helper{
    public class LoginHelper {
        public string email { get; set; }
        public string password { get; set; }
        public LoginHelper(string email, string password) {
            this.email = email;
            this.password = password;
        }
    }
}