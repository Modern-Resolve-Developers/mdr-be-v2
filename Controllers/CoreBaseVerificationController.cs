using danj_backend.Authentication;
using danj_backend.Data;
using danj_backend.Model;
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

    [Route("create-required-verification-cooldowns"), HttpPost]
    public async Task<IActionResult> CreateNewVCCooldowns([FromBody] VerificationCooldown verificationCooldown)
    {
        var result = await _repository.PostNewVerificationCooldowns(verificationCooldown);
        return Ok(result);
    }

    [Route("resend-verification-code/{type}/{email}"), HttpPost]
    public async Task<IActionResult> ResendVerificationCode([FromRoute] string type, [FromRoute] string email)
    {
        var result = await _repository.SMSResendVerificationCode(type, email);
        return Ok(result);
    }

    [Route("look-resent-load/{email}"), HttpGet]
    public async Task<IActionResult> LookResentLoad([FromRoute] string email)
    {
        var result = await _repository.CheckVerificationCountsWhenLoad(email);
        if (result == 400)
        {
            return BadRequest();
        }
        else
        {
            return Ok(result);
        }
    }

    [Route("check-verification-code/{code}/{email}/{type}"), HttpPost]
    public async Task<IActionResult> VerifyCode([FromRoute] string code, [FromRoute] string email,
        [FromRoute] string? type)
    {
        var result = await _repository.SMSCheckVerificationCode(code, email, type);
        return Ok(result);
    }

    [Route("re-validate-resent-code/{email}"), HttpPut]
    public async Task<IActionResult> RevalidateResentCode([FromRoute] string email)
    {
        var result = await _repository.CheckVerificationAfter24Hours(email);
        return Ok(result);
    }
}