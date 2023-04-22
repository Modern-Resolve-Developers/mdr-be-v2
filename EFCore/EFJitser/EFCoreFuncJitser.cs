using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFJitser;

public class EFCoreFuncJitser : EFCoreJitserRepository<Jitser, ApiDbContext>
{
    public EFCoreFuncJitser(ApiDbContext context) : base(context){}
}