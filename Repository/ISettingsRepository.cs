using danj_backend.Data;

namespace danj_backend.Repository;

public interface ISettingsRepository<T> where T : class, ISettings
{
    Task<T> initializeDashboardSettings(T entity);
    List<T> getDashboardSettings();
}