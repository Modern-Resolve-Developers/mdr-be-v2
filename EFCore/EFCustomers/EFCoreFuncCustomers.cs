using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFCustomers;

public class EFCoreFuncCustomers : EFCoreCustomerRepository<Customers, ApiDbContext>
{
    public EFCoreFuncCustomers(ApiDbContext context) : base(context){}
}