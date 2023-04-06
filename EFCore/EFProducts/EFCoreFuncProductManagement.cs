using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFProducts;

public class EFCoreFuncProductManagement : EFCoreProductManagementRepository<ProductManagement, ApiDbContext>
{
    public EFCoreFuncProductManagement(ApiDbContext context) : base(context){}
}