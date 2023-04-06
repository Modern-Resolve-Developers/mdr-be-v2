using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("system_gen")]
public class SystemGenerator: ISystemGen
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int genCodeId { get; set; }
    [Display(Name = "ProductManagement")]
    public virtual int product_id { get; set; }
    [ForeignKey("product_id")]
    public virtual ProductManagement? ProductManagement { get; set; }
    public Guid systemCode { get; set; }
    public char status { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}