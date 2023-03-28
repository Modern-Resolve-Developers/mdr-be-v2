using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class jwtInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var jwtAuthentication = @"
                   create table jwt_authentication(
                       jwtId int not null identity primary key,
                       jwtusername varchar(255),
                       jwtpassword varchar(max),
                       isValid char(1)
                   )
            ";
            migrationBuilder.Sql(jwtAuthentication);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "jwt_authentication");
        }
    }
}
