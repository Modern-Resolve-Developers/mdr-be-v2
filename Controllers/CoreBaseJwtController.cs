using danj_backend.Data;
using danj_backend.Helper;
using danj_backend.Model;
using danj_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseJwtController<TEntity, TRepository> : ControllerBase
where TEntity : class, IJWTToken
where TRepository : IJWTRepository<TEntity>
{
    private readonly TRepository repository;
    private readonly JwtSettings jwtSettings;
    public CoreBaseJwtController(TRepository repository, JwtSettings jwtSettings)
    {
        this.repository = repository;
        this.jwtSettings = jwtSettings;
    }

    [Route("secure-token-create-account"), HttpPost]
    public async Task<IActionResult> CreateAccountCredentialsToken(TEntity entity)
    {
        var result = await repository.createUserOnJwt(entity);
        return Ok(result);
    }

    [Route("secure-token-generate-context"), HttpPost]
    public IActionResult GetToken(string jwtusername, string jwtpassword)
    {
        try
        {
            var resultBool = repository.JWTDynamicQuery(x => x.jwtusername == jwtusername && x.isValid == Convert.ToChar("1"));
            var resultByDefault = repository.JWTDynamicQueryFirstOrDefault(x =>
                x.jwtusername == jwtusername && x.isValid == Convert.ToChar("1"));
            if (resultBool)
            {
                string EncryptedJWTPassword = resultByDefault == null ? "" : resultByDefault.jwtpassword;
                if (BCrypt.Net.BCrypt.Verify(jwtpassword, EncryptedJWTPassword))
                {
                    var Token = new UserTokens();
                    if (resultByDefault.isValid == Convert.ToChar("1"))
                    {
                        Token = JwtHelpers.JwtHelpers.GenTokenKey(new UserTokens()
                        {
                            EmailId = resultByDefault.jwtusername,
                            GuidId = Guid.NewGuid(),
                            UserName = resultByDefault.jwtusername,
                            Id = resultByDefault.jwtId
                        }, jwtSettings);
                        return Ok(Token);
                    }
                    else
                    {
                        return Ok("INVALID_TOKEN_NOT_VALID");
                    }
                }
                else
                {
                    return Ok("INVALID_CREDENTIALS_PASSWORD");
                }
            }
            else
            {
                return Ok("JWT_ACCOUNT_NOT_FOUND");
            }
            return Ok("INVALID_CREDENTIALS_WRONG_USERNAME_OR_PASSWORD");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}