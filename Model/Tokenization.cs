using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model
{
    [Table("tokenization")]
    public class Tokenization : IToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tokenId { get; set; }
        [Required]
        public int userId { get; set; }
        public string token { get; set; }
        public char isExpired { get; set; }
        public char isValid { get; set; }
        [DataType(DataType.Date)]
        public DateTime created_at { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated_at { get; set; }
        [DataType(DataType.Date)]
        public DateTime expiration { get; set; }
    }
}