using danj_backend.Authentication;
using danj_backend.EFCore.EFProducts;
using danj_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Products;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ProductManagementController : CoreBaseProductManagementController<ProductManagement, EFCoreFuncProductManagement>
{
    public ProductManagementController(EFCoreFuncProductManagement repository) : base(repository) {}
}