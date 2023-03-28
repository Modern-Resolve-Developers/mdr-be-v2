namespace danj_backend.Helper
{
    public class PersonalDetails
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public PersonalDetails(int Id, string firstname, string middlename, string lastname) {
            this.Id = Id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.middlename = middlename;
        }
    }
}
