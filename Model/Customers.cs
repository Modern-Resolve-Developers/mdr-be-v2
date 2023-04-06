using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("customers")]
public class Customers : ICustomers
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int customerId { get; set; }
    [Required]
    public string customerName { get; set; }
    public string customerEmail { get; set; }
    public string customerPassword { get; set; }
    public string customerImageUrl { get; set; }
    public char verified { get; set; }
    public char isstatus { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}