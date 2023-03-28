using danj_backend.Authentication;
using danj_backend.EFCore;
using danj_backend.EFCore.EFUsers;
using danj_backend.Helper;
using danj_backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.JWT
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]

    public class JWTController : CoreBaseJwtController<JWTAuthentication, EFCoreFuncJWTRepository>
    {
        public JWTController(EFCoreFuncJWTRepository repository, JwtSettings jwtSettings) : base(repository, jwtSettings){}
    }
}
