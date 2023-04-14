namespace danj_backend.Data;

public interface ICustomers
{
    int customerId { get; set; }
    string customerName { get; set; }
    string customerEmail { get; set; }
    string customerPassword { get; set; }
    string customerImageUrl { get; set; }
    char verified { get; set; }
    char isstatus { get; set; }
    DateTime created_at { get; set; }
    DateTime updated_at { get; set; }
}