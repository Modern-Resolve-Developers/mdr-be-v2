using danj_backend.DB;
using danj_backend.Helper;
using danj_backend.Model;
using Microsoft.Extensions.Options;

namespace danj_backend.EFCore.EFVerification;

public class EFCoreFuncVerification: EFCoreVerification<Verification, ApiDbContext>
{
    public EFCoreFuncVerification(ApiDbContext context, IOptions<MailSettings> mailSettings) : base(context, mailSettings) {}
}