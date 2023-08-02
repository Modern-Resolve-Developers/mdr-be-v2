using danj_backend.EFCore.EFVerification;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Verification;

public class VerificationController : CoreBaseVerificationController<Model.Verification, EFCoreFuncVerification>
{
   public VerificationController(EFCoreFuncVerification repository) : base(repository){}
}