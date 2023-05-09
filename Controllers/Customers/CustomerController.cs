using danj_backend.Authentication;
using danj_backend.EFCore.EFCustomers;
using Microsoft.AspNetCore.Mvc;

namespace danj_backend.Controllers.Customers;
[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class CustomerController : CoreBaseCustomerController<Model.Customers, EFCoreFuncCustomers>
{
    public CustomerController(EFCoreFuncCustomers coreFuncCustomers) : base(coreFuncCustomers){}
}