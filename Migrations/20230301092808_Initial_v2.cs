using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authentication_history",
                columns: table => new
                {
                    authId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    savedAuth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isValid = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authentication_history", x => x.authId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authentication_history");
        }
    }
}
