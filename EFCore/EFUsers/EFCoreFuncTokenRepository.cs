using danj_backend.Model;
using danj_backend.DB;

namespace danj_backend.EFCore.EFUsers
{
    public class EFCoreFuncTokenRepository : EFCoreTokenRepository<Tokenization, ApiDbContext>
    {
        public EFCoreFuncTokenRepository(ApiDbContext context) : base(context)
        {

        }
    }
}