using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class Prod_Sprint2_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
           

          

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verified = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    isstatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "dg_jitser_meet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isPrivate = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    roomStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    roomUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_jitser_meet", x => x.id);
                });

            

            migrationBuilder.CreateTable(
                name: "product_features_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_features_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_management",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectScale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productPrice = table.Column<float>(type: "real", nullable: false),
                    projectInstallment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    installmentInterest = table.Column<float>(type: "real", nullable: false),
                    monthsToPay = table.Column<int>(type: "int", nullable: false),
                    downPayment = table.Column<float>(type: "real", nullable: false),
                    monthlyPayment = table.Column<float>(type: "real", nullable: false),
                    totalPayment = table.Column<float>(type: "real", nullable: false),
                    repositoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maintainedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    repositoryZipUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IsUnderMaintenance = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_management", x => x.id);
                });


            migrationBuilder.CreateTable(
                name: "system_gen",
                columns: table => new
                {
                    genCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    systemCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_gen", x => x.genCodeId);
                    table.ForeignKey(
                        name: "FK_system_gen_product_management_product_id",
                        column: x => x.product_id,
                        principalTable: "product_management",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

           
            

            migrationBuilder.CreateIndex(
                name: "IX_system_gen_product_id",
                table: "system_gen",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "dg_jitser_meet");

            migrationBuilder.DropTable(
                name: "fp_verifier");

            migrationBuilder.DropTable(
                name: "jwt_authentication");

            migrationBuilder.DropTable(
                name: "mdr_task_management");

            migrationBuilder.DropTable(
                name: "product_features_category");

            migrationBuilder.DropTable(
                name: "system_gen");

            migrationBuilder.DropTable(
                name: "token_model");

            migrationBuilder.DropTable(
                name: "tokenization");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "product_management");
        }
    }
}
