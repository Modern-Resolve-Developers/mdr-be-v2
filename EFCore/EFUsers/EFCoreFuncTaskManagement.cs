using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFUsers
{
    public class EFCoreFuncTaskManagement : EFCoreTaskManagementRepository<MDR_Task_Management, ApiDbContext>
    {
        public EFCoreFuncTaskManagement(ApiDbContext context) : base(context) { }
    }
}
