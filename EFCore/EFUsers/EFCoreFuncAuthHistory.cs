using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFUsers
{
    public class EFCoreFuncAuthHistory : EFCoreAuthHistoryRepository<Authentication_history, ApiDbContext>
    {
        public EFCoreFuncAuthHistory(ApiDbContext context) : base(context) { }
    }
}
