using danj_backend.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using danj_backend.Repository;
using danj_backend.DB;
using Microsoft.EntityFrameworkCore;
using danj_backend.Model;
using danj_backend.EFCore.EFUsers;

namespace danj_backend.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class UsersController : CoreBaseController<danj_backend.Model.Users, EFCoreUsersRepository>
    {

        public UsersController(EFCoreUsersRepository repository) : base(repository)
        {

        }
    }
}
