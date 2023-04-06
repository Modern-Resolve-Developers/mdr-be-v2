using danj_backend.DB;
using danj_backend.Model;

namespace danj_backend.EFCore.EFSystemGen;

public class EFCoreFuncSystemGen : EFCoreSystemGenRepository<SystemGenerator, ApiDbContext>
{
    public EFCoreFuncSystemGen(ApiDbContext context) : base(context){}
}