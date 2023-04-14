using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using danj_backend.Data;

namespace danj_backend.Model;
[Table("product_management")]
public class ProductManagement: IProductManagement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [Required]
    public string productName { get; set; }
    public string productDescription { get; set; }
    public string productCategory { get; set; }
    public string productFeatures { get; set; }
    public string projectType { get; set; }
    public string productImageUrl { get; set; }
    public string projectScale { get; set; }
    public float productPrice { get; set; }
    public string projectInstallment { get; set; }
    public float installmentInterest { get; set; }
    public int monthsToPay { get; set; }
    public float downPayment { get; set; }
    public float monthlyPayment { get; set; }
    public float totalPayment { get; set; }
    public string repositoryName { get; set; }
    public string maintainedBy { get; set; }
    public string repositoryZipUrl { get; set; }
    public char productStatus { get; set; }
    public char IsUnderMaintenance { get; set; }
    public string created_by { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}