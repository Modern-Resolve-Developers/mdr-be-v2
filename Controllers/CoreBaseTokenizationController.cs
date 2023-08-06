using Microsoft.AspNetCore.Mvc;
using danj_backend.Data;
using danj_backend.Repository;
using danj_backend.Helper;
using System.Dynamic;
using danj_backend.Model;

namespace danj_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CoreBaseTokenizationController<TEntity, TRepository> : ControllerBase
    where TEntity : class, IToken
    where TRepository : ITokenizationRepository<TEntity>
    {
        private readonly TRepository repository;

        public CoreBaseTokenizationController(TRepository repository)
        {
            this.repository = repository;
        }

        [Route("create-token"), HttpPost]
        public ActionResult create(TEntity entity)
        {
            if (repository.FindInTokenIfExist(x => x.userId == entity.userId && x.isValid == Convert.ToChar("1")))
            {
                /* token exist and it is valid */
                var result = repository.FetchToken(x => x.userId == entity.userId && x.isValid == Convert.ToChar("1"));
                dynamic dynObject = new ExpandoObject();
                dynObject.tokenResult = result;
                dynObject.message = "token-exist-success";
                return Ok(dynObject);
            } 
            else
            {
                repository.CreateToken(entity);
                var result = repository.FetchToken(x => x.userId == entity.userId);
                dynamic dynObject = new ExpandoObject();
                dynObject.tokenResult = result;
                dynObject.message = "token-creation-success";
                return Ok(dynObject);
            }
        }
        //if this API is [Authorize] then on the frontend side we should call the refresh token before processing the signout.
        [Route("destroy-signout/{id}"), HttpPut]
        public ActionResult DestroyToken(int id)
        {
            if(id <= 0)
            {
                return BadRequest("invalid_id");
            }
            else
            {
                var identifyUsers = repository.FindUsersById(x => x.userId == id);
                if(identifyUsers != null)
                {
                    repository.ChangeToZeroIsValid(id);
                    return Ok("success_destroy");
                }
                else
                {
                    return Ok("user_not_found");
                }
            }
        }

        [Route("identify-user-type/{userid}"), HttpGet]
        public ActionResult IdentifyUserType(int userid)
        {
            var result = repository.IdentifyAuthentication(userid);
            return Ok(result);
        }
    }
}