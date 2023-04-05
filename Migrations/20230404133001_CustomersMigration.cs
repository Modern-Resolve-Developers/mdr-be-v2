using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class CustomersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var customersCreation = @"
                create table customers(
                    customerId int not null identity primary key,
                    customerName varchar(100),
                    customerEmail varchar(255),
                    customerPassword varchar(255),
                    customerImageUrl varchar(max),
                    verified char(1),
                    isstatus char(1),
                    created_at datetime default current_timestamp,
                    updated_at datetime default current_timestamp
                )
            ";
            migrationBuilder.Sql(customersCreation);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "customers");
        }
    }
}
