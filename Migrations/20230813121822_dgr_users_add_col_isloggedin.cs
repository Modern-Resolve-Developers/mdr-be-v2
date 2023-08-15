using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class dgr_users_add_col_isloggedin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "accountIsLoggedIn",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name:"accountIsLoggedIn",
                table:"users"
                );
        }
    }
}
