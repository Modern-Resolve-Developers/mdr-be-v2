

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model
{
    [Table("users")]
    public class Users : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        [Required]
        public string email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
        public string? imgurl { get; set; }
        public char isstatus { get ; set; }
        public char verified { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public char userType { get; set; }
    }
}