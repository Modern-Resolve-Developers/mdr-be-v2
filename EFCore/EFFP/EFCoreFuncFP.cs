using danj_backend.DB;
using danj_backend.Helper;
using danj_backend.Model;
using Microsoft.Extensions.Options;

namespace danj_backend.EFCore.EFFP;

public class EFCoreFuncFP : EFCoreFPRepository<FP, ApiDbContext>
{
    public EFCoreFuncFP(ApiDbContext context, IOptions<MailSettings> mailSettings) : base(context, mailSettings){}
}