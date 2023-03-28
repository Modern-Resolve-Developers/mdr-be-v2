using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class Authentication_history : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "preserve_data",
                table: "authentication_history",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "preserve_data",
                table: "authentication_history");
        }
    }
}
