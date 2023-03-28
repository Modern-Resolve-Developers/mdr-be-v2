using danj_backend.Authentication;
using Microsoft.AspNetCore.Mvc;
using danj_backend.Model;
using danj_backend.EFCore.EFUsers;

namespace danj_backend.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class TokenController : CoreBaseTokenizationController<Tokenization, EFCoreFuncTokenRepository>
    {
        public TokenController(EFCoreFuncTokenRepository repository) : base(repository)
        {

        }
    }
}