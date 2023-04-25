using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseJitserController<TEntity, TRepository> : ControllerBase
where TEntity : class, IJitser
where TRepository : IJitserRepository<TEntity>
{
    private readonly TRepository _repository;

    public CoreBaseJitserController(TRepository repository)
    {
        this._repository = repository;
    }

    [Authorize]
    [Route("store-jitser-details"), HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> storeJitserMeetDetails([FromBody] TEntity entity)
    {
        if (_repository.meetDetailsCheck(x => x.roomName == entity.roomName))
        {
            return Ok("room-name-exist");
        }
        else
        {
            await _repository.storeMeetDetails(entity);
            return Ok(200);
        }
    }
    [Authorize]
    [Route("get-all-rooms"), HttpGet]
    public async Task<IActionResult> getAllRooms()
    {
        var result = await _repository.getAllRooms();
        return Ok(result);
    }
}