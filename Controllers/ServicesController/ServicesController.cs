using danj_backend.Authentication;
using danj_backend.Helper;
using danj_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.ServicesController;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ServicesController : Controller
{
   private readonly IMailService _mailService;

   public ServicesController(IMailService mailService)
   {
      this._mailService = mailService;
   }

   [Route("send-email-sample"), HttpPost]
   public async Task<IActionResult> SendEmail([FromForm] MailRequest request)
   {
      await _mailService.SendEmailAsync(request);
      return Ok(200);
   }

}