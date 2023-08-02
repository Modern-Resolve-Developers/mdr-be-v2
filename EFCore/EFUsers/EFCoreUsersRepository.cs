using danj_backend.Model;
using danj_backend.EFCore;
using danj_backend.DB;
using danj_backend.Helper;

namespace danj_backend.EFCore.EFUsers
{
    public class EFCoreUsersRepository : EFCoreRepository<Users, ApiDbContext>
    {
        public EFCoreUsersRepository(ApiDbContext context) : base(context)
        {

        }
    }
}