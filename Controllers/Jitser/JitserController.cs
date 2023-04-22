using danj_backend.EFCore.EFJitser;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Jitser;

public class JitserController : CoreBaseJitserController<Model.Jitser, EFCoreFuncJitser>
{
    public JitserController(EFCoreFuncJitser repository) : base(repository) {}
}