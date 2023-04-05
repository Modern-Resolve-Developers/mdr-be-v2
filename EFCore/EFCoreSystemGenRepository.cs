using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Model;
using danj_backend.Repository;

namespace danj_backend.EFCore;

public class EFCoreSystemGenRepository<TEntity, TContext> : ISystemGenRepository<TEntity>
where TEntity : class, ISystemGen
where TContext: ApiDbContext
{
    private readonly TContext _context;

    public EFCoreSystemGenRepository(TContext context)
    {
        this._context = context;
    }

    public TEntity genSystemGen(TEntity entity)
    {
        entity.systemCode = Guid.NewGuid();
        entity.status = Convert.ToChar("1");
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }
}