using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class MDR_Task_Management_ChangeColType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var alterAssignee = @"
               ALTER TABLE mdr_task_management
ALTER COLUMN assignee_userid int;
            ";
            migrationBuilder.Sql(alterAssignee);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                    name: "mdr_task_management"
                );
        }
    }
}
