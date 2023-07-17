using danj_backend.Authentication;
using danj_backend.EFCore.EFSettings;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Settings;
[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class SettingsController : CoreBaseSettingsController<Model.Settings, EFCoreFuncSettings>
{
    public SettingsController(EFCoreFuncSettings repository) : base(repository) {}
}