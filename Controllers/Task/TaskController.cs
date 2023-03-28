using danj_backend.Authentication;
using danj_backend.EFCore;
using danj_backend.EFCore.EFUsers;
using danj_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Task
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class TaskController : CoreBaseTaskManagementController<MDR_Task_Management, EFCoreFuncTaskManagement>
    {
        public TaskController(EFCoreFuncTaskManagement repository) : base(repository) { }
    }
}
