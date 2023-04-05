using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Repository;

namespace danj_backend.EFCore;

public abstract class EFCoreProductCategRepository<TEntity, TContext> : IProductFeatCategoryRepository<TEntity>
 where TEntity : class, IProdCategFeatures
 where TContext: ApiDbContext
{
    private readonly TContext context;

    public EFCoreProductCategRepository(TContext context)
    {
        this.context = context;
    }

    public List<TEntity> getAllMultiSelect()
    {
        return context.Set<TEntity>().ToList();
    }
}