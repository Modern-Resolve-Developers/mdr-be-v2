using danj_backend.Model;
using danj_backend.EFCore;
using danj_backend.DB;

namespace danj_backend.EFCore.EFUsers
{
    public class EFCoreUsersRepository : EFCoreRepository<Users, ApiDbContext>
    {
        public EFCoreUsersRepository(ApiDbContext context) : base(context)
        {

        }
    }
}