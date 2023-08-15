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
            var result = await _repository.storeMeetDetails(entity);
            return Ok(result);
        }
    }
    
    
    [Route("get-all-rooms"), HttpGet]
    public async Task<IActionResult> getAllRooms()
    {
        var result = await _repository.getAllRooms();
        return Ok(result);
    }
    
    [Authorize]
    [Route("join-meet/{name}/{roomId}"), HttpPost]
    public async Task<IActionResult> joinRoom(string name, int roomId)
    {
        var result = await _repository.WhenJoinMeet(roomId, name);
        return Ok(result);
    }
    
    [Authorize]
    [Route("hang-out-meeting/{name}"), HttpDelete]
    public async Task<IActionResult> HangOutCall(string name)
    {
        var result = await _repository.HangoutMeet(name);
        return Ok(result);
    }
    [Authorize]
    [Route("delete-room/{id}"), HttpDelete]
    public async Task<IActionResult> deleteRoom(int id)
    {
        var result = await _repository.deleteRoom(id);
        return Ok(result);
    }
}