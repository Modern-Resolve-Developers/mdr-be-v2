using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CoreBaseTaskManagementController<TEntity, TRepository> : ControllerBase
    where TEntity : class, ITaskManagement
    where TRepository : ITaskManagementRepository<TEntity>
    {
        private readonly TRepository repository;

        public CoreBaseTaskManagementController(TRepository repository)
        {
            this.repository = repository;
        }

        [Route("fetch-users-based-usertype/{usertype}"), HttpGet]
        public ActionResult FetchUsersBasedOnUserType(char usertype)
        {
            var result = repository.getAllUsers(usertype);
            return Ok(result);
        }

        [Route("create-task"), HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult CreateTask(TEntity task)
        {
            repository.createTask(task);
            return Ok("task_created");
        }

        [Route("get-all-task"), HttpGet]
        public ActionResult GetAllTask()
        {
            var result = repository.getAllTask();
            return Ok(result);
        }

        [Route("delete-ticket/{id}"), HttpDelete]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await repository.DeleteTicket(id);
            return Ok("success_delete");
        }
    }
}
