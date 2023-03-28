using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFUsers;

public class EFCoreFuncJWTRepository : EFCoreJwtRepository<JWTAuthentication, ApiDbContext>
{
    public EFCoreFuncJWTRepository(ApiDbContext context) : base(context){}
}