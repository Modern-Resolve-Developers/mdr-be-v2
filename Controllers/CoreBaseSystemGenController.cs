using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseSystemGenController<TEntity, TRepository> : ControllerBase
where TEntity : class, ISystemGen
where TRepository : ISystemGenRepository<TEntity>
{
    private readonly TRepository _repository;

    public CoreBaseSystemGenController(TRepository repository)
    {
        this._repository = repository;
    }
    
    [Route("gen-products-system-gen"), HttpPost]
    public ActionResult genNewSystemCode(TEntity entity)
    {
        _repository.genSystemGen(entity);
        return Ok(200);
    }
}