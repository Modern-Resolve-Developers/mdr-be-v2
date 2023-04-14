using danj_backend.Data;
using danj_backend.Repository;
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

    [Route("fetch-all-category"), HttpGet]
    public ActionResult fetchAllCategory()
    {
        var result = _repository.getAllMultiSelect();
        return Ok(result);
    }
}