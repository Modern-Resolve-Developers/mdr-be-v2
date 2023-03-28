using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class TaskManagement_InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var taskManagementTable = @"
                        create table mdr_task_management (
                        id int not null identity primary key,
                        taskCode bigint,
                        title varchar(100),
                        description text,
                        subtask varchar(max),
                        imgurl varchar(max),
                        priority varchar(50),
                        assignee varchar(100),
                        reporter varchar(100),
                        task_dept varchar(150),
                        task_status char(1),
                        created_by varchar(100),
                        created_at datetime default current_timestamp,
                        updated_at datetime default current_timestamp
                        )
                ";
            migrationBuilder.Sql(taskManagementTable);
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
