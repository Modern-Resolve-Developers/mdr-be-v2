using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model
{
    [Table("dynamic_routing")]
    public class DynamicRouting : IDynamicRouting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int access_level { get; set; }
        public Guid requestId { get; set; }
        public string ToWhomRoute { get; set; }
        public string exactPath { get; set; }
        public DateTime created_at { get; set; }
    }
}