using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseProdCategoryController<TEntity, TRepository> : Controller
where TEntity : class, IProdCategFeatures
where TRepository : IProductFeatCategoryRepository<TEntity>
{
    private readonly TRepository _repository;

    public CoreBaseProdCategoryController(TRepository repository)
    {
        this._repository = repository;
    }
    
    [Authorize]
    [Route("fetch-all-category"), HttpGet]
    public ActionResult fetchAllCategory()
    {
        var result = _repository.getAllMultiSelect();
        return Ok(result);
    }

    [Authorize]
    [Route("create-new-category"), HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> createNewCategory(TEntity entity)
    {
        await _repository.createNewCategory(entity);
        return Ok(200);
    }

    [Authorize]
    [Route("get-all-new-categories"), HttpGet]
    public async Task<IActionResult> getAllNewCategories()
    {
        var result = await _repository.getAllNewCategories();
        return Ok(result);
    }
}