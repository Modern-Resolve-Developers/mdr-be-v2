namespace danj_backend.Data;

public interface IProductManagement
{
    int id { get; set; }
    string productName { get; set; }
    string productDescription { get; set; }
    string productCategory { get; set; }
    string productFeatures { get; set; }
    string projectType { get; set; }
    string productImageUrl { get; set; }
    string projectScale { get; set; }
    float productPrice { get; set; }
    string projectInstallment { get; set; }
    float installmentInterest { get; set; }
    int monthsToPay { get; set; }
    float downPayment { get; set; }
    float monthlyPayment { get; set; }
    float totalPayment { get; set; }
    string repositoryName { get; set; }
    string maintainedBy { get; set; }
    string repositoryZipUrl { get; set; }
    char productStatus { get; set; }
    char IsUnderMaintenance { get; set; }
    string created_by { get; set; }
    DateTime created_at { get; set; }
    DateTime updated_at { get; set; }
}