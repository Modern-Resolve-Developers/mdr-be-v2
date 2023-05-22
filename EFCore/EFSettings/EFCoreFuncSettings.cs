using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFSettings;

public class EFCoreFuncSettings : EFCoreSettingsRepository<Settings, ApiDbContext>
{
    public EFCoreFuncSettings(ApiDbContext context) : base(context) {}
}