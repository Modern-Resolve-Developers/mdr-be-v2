using danj_backend.JwtHelpers;
using danj_backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace danj_backend.DB
{
    public class ApiDbContext : IdentityDbContext<ApplicationAuthentication>
    {
        // IdentityDbContext<ApplicationAuthentication>
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Ignore<Users>();
            // builder.Ignore<Tokenization>();
            // builder.Ignore<Authentication_history>();
            // builder.Ignore<MDR_Task_Management>();
            // builder.Ignore<JWTAuthentication>();
            // builder.Ignore<TokenModel>();
            // builder.Ignore<Product_Features_Category>();
            // builder.Ignore<ProductManagement>();
            // builder.Ignore<Customers>();
            // builder.Ignore<SystemGenerator>();
            // builder.Ignore<Jitser>();
            // builder.Ignore<FP>();
            // builder.Ignore<JitsiJoinedPersons>();
            // builder.Ignore<Settings>();
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tokenization> Tokenization { get; set; }

        public DbSet<Authentication_history> authentication_Histories { get; set; }
        public DbSet<MDR_Task_Management> mDR_Task_Managements { get; set; }
        public DbSet<JWTAuthentication> JwtAuthentications { get; set; }

        public DbSet<TokenModel> tokenModels { get; set; }
        public DbSet<Product_Features_Category> ProductFeaturesCategories { get; set; }
        public DbSet<ProductManagement> ProductManagements { get; set; }
        public DbSet<Customers> CustomersEnumerable { get; set; }
        public DbSet<SystemGenerator> SystemGenerators { get; set; }
        public DbSet<Jitser> Jitsers { get; set; }
        public DbSet<FP> Fps { get; set; }
        public DbSet<JitsiJoinedPersons> JitsiJoinedPersonsEnumerable { get; set; }
        public DbSet<Settings> SettingsEnu { get; set; }
    }
}