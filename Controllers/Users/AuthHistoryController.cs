using danj_backend.Authentication;
using danj_backend.EFCore;
using danj_backend.EFCore.EFUsers;
using danj_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class AuthHistoryController : CoreBaseAuthHistoryController<Authentication_history, EFCoreFuncAuthHistory>
    {
        public AuthHistoryController(EFCoreFuncAuthHistory repository) : base(repository) { }
    }
}
