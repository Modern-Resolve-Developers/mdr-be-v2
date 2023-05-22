using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseSettingsController<TEntity, TRepository> : ControllerBase
where TEntity : class, ISettings
where TRepository : ISettingsRepository<TEntity>
{
    private readonly TRepository _repository;

    public CoreBaseSettingsController(TRepository repository)
    {
        this._repository = repository;
    }

    [Authorize]
    [Route("create-new-settings-dashboard"), HttpPost]
    public async Task<IActionResult> newDashboardSettings(TEntity entity)
    {
        await _repository.initializeDashboardSettings(entity);
        return Ok(200);
    }
 
    [Authorize]
    [Route("get-all-dashboard-settings"), HttpGet]
    public ActionResult getAllDashboardSettings()
    {
        var result = _repository.getDashboardSettings();
        return Ok(result);
    }
}