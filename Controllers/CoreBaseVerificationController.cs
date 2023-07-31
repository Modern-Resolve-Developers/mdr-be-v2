using danj_backend.Authentication;
using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public abstract class CoreBaseVerificationController<TEntity, TRepository> : ControllerBase
where TEntity : class, IVerification
where TRepository : IVerificationRepository<TEntity>
{
    private readonly TRepository _repository;

    public CoreBaseVerificationController(TRepository repository)
    {
        this._repository = repository;
    }

    [Route("send-verification-code/{email}/{phoneNumber}"), HttpPost]
    public async Task<IActionResult> SendVerificationCode([FromBody] TEntity entity, [FromRoute] string email,
        [FromRoute] string phoneNumber)
    {
        var result = await _repository.SMSVerificationDataManagement(entity, new()
        {
            email = email,
            phoneNumber = phoneNumber
        });
        return Ok(result);
    }

    [Route("check-verification-code/{code}/{email}/{type}"), HttpPost]
    public async Task<IActionResult> VerifyCode([FromRoute] string code, [FromRoute] string email,
        [FromRoute] string? type)
    {
        var result = await _repository.SMSCheckVerificationCode(code, email, type);
        return Ok(result);
    }
}