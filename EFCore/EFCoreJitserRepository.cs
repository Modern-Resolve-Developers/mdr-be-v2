using System.Linq.Expressions;
using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Repository;

namespace danj_backend.EFCore;

public class EFCoreJitserRepository<TEntity, TContext> : IJitserRepository<TEntity>
where TEntity : class, IJitser
where TContext: ApiDbContext
{
    private readonly TContext context;

    public EFCoreJitserRepository(TContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> storeMeetDetails(TEntity entity)
    {
        entity.createdBy = "Administrator";
        entity.roomPassword = BCrypt.Net.BCrypt.HashPassword(entity.roomPassword);
        entity.roomStatus = Convert.ToChar("1");
        entity.createdAt = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
        entity.updatedAt = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public Boolean meetDetailsCheck(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Any(predicate);
    }

    public async Task<List<TEntity>> getAllRooms()
    {
        return context.Set<TEntity>().Where(x => x.roomStatus == Convert.ToChar("1")).ToList();
    }
}