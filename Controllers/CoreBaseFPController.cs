using danj_backend.Data;
using danj_backend.Helper;
using danj_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseFPController<TEntity, TRepository> : ControllerBase
where TEntity : class, IFP
where TRepository : IFPRepository<TEntity>
{
    private readonly TRepository repository;
    
    public CoreBaseFPController(TRepository repository)
    {
        this.repository = repository;
    }

    [Route("send-fp-email/{email}"), HttpPost]
    public async Task<IActionResult> fpSendEmail([FromRoute] string email)
    {
        var result = await repository.findAnyFPVerified(email);
        return Ok(result);
    }

    [Route("check-code-verification/{code}/{email}"), HttpPost]
    public async Task<IActionResult> checkVerification([FromRoute] string code, string email)
    {
        var result = await repository.CheckVerificationCodeEntry(code, email);
        return Ok(result);
    }

    [Route("resend-code-verification/{email}"), HttpPost]
    public async Task<IActionResult> resendVerification([FromRoute] string email)
    {
        var result = await repository.ResendVerificationCode(email);
        return Ok(result);
    }

    [Route("fp-change-password"), HttpPost]
    public async Task<IActionResult> changePassword([FromBody] FPChangePassword fpChangePassword)
    {
        var result = await repository.ChangePasswordWhenVerified(fpChangePassword);
        return Ok(result);
    }
}