using danj_backend.Authentication;
using danj_backend.EFCore.EFSystemGen;
using danj_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.SystemCodeGen;
[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class SystemGenController : CoreBaseSystemGenController<SystemGenerator, EFCoreFuncSystemGen>
{
    public SystemGenController(EFCoreFuncSystemGen repository) : base(repository){}
}