using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace danj_backend.EFCore;

public class EFCoreSettingsRepository<TEntity, TContext> : ISettingsRepository<TEntity>
where TEntity : class, ISettings
where TContext : ApiDbContext
{
    private readonly TContext context;

    public EFCoreSettingsRepository(TContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> initializeDashboardSettings(TEntity entity)
    {
        var checkExistingSettings = context.Set<TEntity>().Any(x => x.settingsType == entity.settingsType);
        var settingsDashboardUpdater =
            await context.Set<TEntity>().Where(x => x.settingsType == entity).FirstOrDefaultAsync();
        if (checkExistingSettings)
        {
            settingsDashboardUpdater.dynamicDashboardEnabled = entity.dynamicDashboardEnabled;
            await context.SaveChangesAsync();
            return entity;
        }
        else
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }

    public List<TEntity> getDashboardSettings()
    {
        return context.Set<TEntity>().ToList();
    }
}