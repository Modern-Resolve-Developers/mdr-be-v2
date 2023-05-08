using danj_backend.Authentication;
using danj_backend.EFCore.EFFP;
using danj_backend.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace danj_backend.Controllers.FP;
[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class FPController : CoreBaseFPController<Model.FP, EFCoreFuncFP>
{
    public FPController(EFCoreFuncFP repository) : base(repository) {}
}