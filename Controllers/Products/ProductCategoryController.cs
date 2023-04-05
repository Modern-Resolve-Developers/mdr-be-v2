using danj_backend.Authentication;
using danj_backend.EFCore.EFUsers;
using danj_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Products;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ProductCategoryController : CoreBaseProdCategoryController<Product_Features_Category, EFCoreFuncProdCategRepository>
{
        public ProductCategoryController(EFCoreFuncProdCategRepository repository) : base(repository){}
}