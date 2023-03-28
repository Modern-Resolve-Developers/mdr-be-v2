using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class TaskManagementTaskStatusChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mdr_task_management",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskCode = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtask = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assignee_userid = table.Column<int>(type: "int", nullable: false),
                    reporter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_dept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdr_task_management", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdr_task_management");
        }
    }
}
