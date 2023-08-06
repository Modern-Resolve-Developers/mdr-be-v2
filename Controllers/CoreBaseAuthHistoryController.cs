using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using danj_backend.Authentication;
using danj_backend.Helper;
using Newtonsoft.Json.Linq;

namespace danj_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CoreBaseAuthHistoryController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IAuthHistory
        where TRepository : IAuthHistoryRepository<TEntity>
    {
        private readonly TRepository repository;

        public CoreBaseAuthHistoryController(TRepository repository)
        {
            this.repository = repository;
        }

        [Route("create-auth-history"), HttpPost]
        public ActionResult createAuthHistory(TEntity entity)
        {
            if(repository.FindInAuthHistoryIfExist(
                x => x.userId == entity.userId && x.isValid == Convert.ToChar("1"))){
                return Ok("save-auth-exist");
            } 
            else
            {
                repository.saveAuthHistory(entity);
                return Ok("success-save-auth-history");
            }
        }

        [Route("fetch-created-auth-history/{userId}"), HttpGet]
        public ActionResult getCreatedAuthHistory(int userId)
        {
            var result = repository.FetchAuthHistoryTokenById(x => x.userId == userId && x.isValid == Convert.ToChar("1"));
            dynamic dynObject = new ExpandoObject();
            dynObject.token = result;
            dynObject.message = "fetched";
            return Ok(dynObject);
        }

        [Route("find-secured-route/{uuid}"), HttpGet]
        public async Task<IActionResult> SecuredRouterFound([FromRoute] int uuid)
        {
            var result = await repository.findSecuredRoute(uuid);
            return Ok(result);
        }
        [Route("fetch-saved-auth-history"), HttpPost]
        public ActionResult fetchAndValidatedSavedAuth(SavedAuthHelper savedAuthHelper)
        {
            var result = repository.ValueFetchAuthHistoryTokenById(x => x.userId == savedAuthHelper.userId && x.isValid == Convert.ToChar("1"));
            string EncryptedSavedAuth = savedAuthHelper.savedAuth;
            if (result == null)
            {
                return Ok("no_records");
            }
            else
            {
                if (savedAuthHelper.savedAuth == result.savedAuth)
                {

                    return Ok(result.preserve_data);
                }
                else
                {
                    return Ok("not_match");
                }
            }
        }

    }
}
