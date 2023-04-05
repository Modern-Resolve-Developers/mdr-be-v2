using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class ProductManagementWithCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var productManagementCreation = @"
                create table product_management(
                    product_id int not null identity primary key,
                    productName varchar(255),
                    productDescription varchar(max),
                    productCategory varchar(100),
                    productFeatures varchar(max),
                    projectType varchar(50),
                    productImageUrl varchar(max),
                    projectScale varchar(100),
                    productPrice decimal,
                    projectInstallment varchar(100),
                    installmentInterest int,
                    monthsToPay int,
                    downPayment decimal,
                    monthlyPayment decimal,
                    totalPayment decimal,
                    repositoryName varchar(100),
                    maintainedBy varchar(100),
                    repositoryZipUrl varchar(max),
                    productStatus char(1),
                    IsUnderMaintenance char(1),
                    created_by varchar(50),
                    created_at datetime default current_timestamp,
                    updated_at datetime default current_timestamp
                )
            ";
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
            migrationBuilder.Sql(productManagementCreation);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "product_management");
            migrationBuilder.DropTable(name: "customers");
        }
    }
}
