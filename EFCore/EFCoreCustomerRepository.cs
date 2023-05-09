using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace danj_backend.EFCore;

public class EFCoreCustomerRepository<TEntity, TContext> : ICustomerRepository<TEntity>
where TEntity : class, ICustomers
where TContext : ApiDbContext
{
    private readonly TContext context;

    public EFCoreCustomerRepository(TContext context)
    {
        this.context = context;
    }


    public async Task<dynamic> GoogleAuthLogin(string email)
    {
        var customerEmailIsExist = await context.Set<TEntity>().AnyAsync(x => x.customerEmail == email);
        if (!customerEmailIsExist)
        {
            return "not_exist";
        }
        else
        {
            return "login";
        }
    }

    public async Task<TEntity> ClientAccountCreation(TEntity entity)
    {
        throw new NotImplementedException();
    }
}