using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using danj_backend.Data;
using danj_backend.Repository;
using danj_backend.Helper;
using danj_backend.DB;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;

namespace danj_backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CoreBaseController<TEntity, TRepository> : ControllerBase
    where TEntity : class, IEntity
    where TRepository : IUsersRepository<TEntity>
    {
        private readonly TRepository repository;

        public CoreBaseController(TRepository repository)
        {
            this.repository = repository;
        }

        [Route("add-admin"), HttpPost]
        public async Task<ActionResult<TEntity>> Post([FromBody] TEntity users)
        {

            await repository.AddUserAdmin(users);
            return Ok("Success");
        }

        [Route("check-email/{id}"), HttpGet]
        public ActionResult CheckIfTheresAdmin([FromRoute] int id)
        {
            if (repository.FindUsersExists(id))
            {
                return Ok("exist");
            }
            else
            {
                return Ok("not_exist");
            }
        }

        
        [Route("find-all-users-report"), HttpGet]
        public ActionResult FindAllUsers()
        {
            var result = repository.GetAllUsers();
            return Ok(result);
        }
        [Authorize]
        [Route("uam-add"), HttpPost]
        public IActionResult addUAM(TEntity entity)
        {
            repository.UAM(entity);
            return Ok("success");
        }

        [Authorize]
        [Route("get-all-users"), HttpGet]
        public ActionResult GetAllUsers()
        {
            var result = repository.GetAllUsers();
            return Ok(result);
        }

        [Authorize]
        [Route("uam-check-email/{email}"), HttpGet]
        public ActionResult UAMCheckEmail([FromRoute] string email)
        {
            var checkEmailAny = repository.FindAny(x => x.email== email);
            if (checkEmailAny)
            {
                return Ok("email_exist");
            }
            else
            {
                return Ok("not_exist");
            }
        }

        [Route("uam-check-email-setup/{email}"), HttpGet]
        public ActionResult UAMCheckEmailSetup([FromRoute] string email)
        {
            var checkEmailAny = repository.FindAny(x => x.email == email);
            if (checkEmailAny)
            {
                return Ok("email_exist");
            }
            else
            {
                return Ok("not_exist");
            }
        }

        [Authorize]
        [Route("temp-delete-uam-user/{id}"), HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> deleteUAMTemporary([FromRoute] int id)
        {
            var result = await repository.DeleteUsers(id);
            if (result)
            {
                return Ok(200);
            }

            return BadRequest();
        }

        [Authorize]
        [Route("update-users-personal-details"), HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult UpdatePersonalDetails([FromBody] PersonalDetails personalDetails)
        {
            if(repository.UpdateUsersPersonalDetails(personalDetails))
            {
                return Ok(200);
            }
            return BadRequest();
        }

        [Authorize]
        [Route("update-users-verified-status/{propstype}/{id}"), HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult UpdateUsersVerifiedStatus([FromRoute] string propstype, int id)
        {
            if(repository.UpdateUsersVerifiedAndStatus(propstype, id))
            {
                return Ok(200);
            }
            return BadRequest();
        }
        [Authorize]
        [Route("delete-uam/{id}"), HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteUserFunc([FromRoute] int id)
        {
            await repository.DeleteUAM(id);
            return Ok(200);
        }

        [Route("login"), HttpPost]
        public ActionResult accountLogin([FromBody] LoginHelper loginHelper)
        {
            try
            {
                string email = loginHelper.email;
                string password = loginHelper.password;

                bool findUserByEmailBool = repository.FindAny(x => x.email == email);
                var findUserByEmailDefault = repository.FindEmailExist(x => x.email == email);

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    return Ok("EMPTY");
                }
                else
                {
                    string EncryptedPassword = findUserByEmailDefault == null ? "" : findUserByEmailDefault.password;
                    if (findUserByEmailBool)
                    {
                        if(findUserByEmailDefault.isstatus == Convert.ToChar('0'))
                        {
                            if (BCrypt.Net.BCrypt.Verify(password, EncryptedPassword))
                            {
                                dynamic dynObject = new ExpandoObject();

                                var getResult = repository.FetchAllUsersInformation(x => x.email == email);

                                dynObject.message = "SUCCESS_LOGIN";
                                dynObject.bundle = getResult;
                                return Ok(dynObject);
                            }
                            else
                            {
                                return Ok("INVALID_PASSWORD");
                            }
                        } 
                        else
                        {
                            return Ok("ACCOUNT_LOCK");
                        }
                    }
                    else
                    {
                        return Ok("NOT_FOUND");
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}