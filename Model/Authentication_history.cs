using danj_backend.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace danj_backend.Model
{
    [Table("authentication_history")]
    public class Authentication_history : IAuthHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int authId { get; set; }
        [Required]
        public int userId { get; set; }
        public string savedAuth { get; set; }
        public char isValid { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [Required]
        public string preserve_data { get; set; }
    }
}
