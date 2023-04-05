using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseProductManagementController<TEntity, TRepository> : ControllerBase
where TEntity : class, IProductManagement
where TRepository : IProductManagementRepository<TEntity>
{
   private readonly TRepository _repository;

   public CoreBaseProductManagementController(TRepository repository)
   {
      this._repository = repository;
   }
   
   [Route("create-new-products")]
   [HttpPost]
   public async Task<IActionResult> createProducts(TEntity entity)
   {
      var result = await _repository.createProducts(entity);
      return Ok(result);
   }
}