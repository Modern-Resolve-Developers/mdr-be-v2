using danj_backend.JwtHelpers;
using danj_backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace danj_backend.DB
{
    public class ApiDbContext : IdentityDbContext<ApplicationAuthentication>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tokenization> Tokenization { get; set; }

        public DbSet<Authentication_history> authentication_Histories { get; set; }
        public DbSet<MDR_Task_Management> mDR_Task_Managements { get; set; }
        public DbSet<JWTAuthentication> JwtAuthentications { get; set; }

        public DbSet<TokenModel> tokenModels { get; set; }
    }
}