using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class MDR_Task_Management_Alter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var alterAssignee = @"
               exec sp_rename '[dbo].[mdr_task_management].assignee', 'assignee_userid'
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
