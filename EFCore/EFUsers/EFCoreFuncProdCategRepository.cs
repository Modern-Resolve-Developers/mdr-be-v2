using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFUsers;

public class EFCoreFuncProdCategRepository : EFCoreProductCategRepository<Product_Features_Category, ApiDbContext>
{
    public EFCoreFuncProdCategRepository(ApiDbContext context) : base(context) {}
}