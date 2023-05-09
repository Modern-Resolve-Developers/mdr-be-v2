using danj_backend.Data;
using danj_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CoreBaseCustomerController<TEntity, TRepository> : ControllerBase
where TEntity : class, ICustomers
where TRepository : ICustomerRepository<TEntity>
{
    private readonly TRepository _repository;

    public CoreBaseCustomerController(TRepository repository)
    {
        this._repository = repository;
    }

    [Route("customer-google-login/{email}"), HttpPost]
    public async Task<IActionResult> googleLogin(string email)
    {
        var result = await _repository.GoogleAuthLogin(email);
        return Ok(result);
    }
}