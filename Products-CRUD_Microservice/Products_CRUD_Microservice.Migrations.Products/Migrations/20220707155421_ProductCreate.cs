using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products_CRUD_Microservice.Migrations.Products.Migrations
{
    public partial class ProductCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    PRD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRD_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PRD_Description = table.Column<string>(type: "TEXT", nullable: true),
                    PRD_Price = table.Column<decimal>(type: "MONEY", nullable: false),
                    PRD_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PRD_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PRD_Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.PRD_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PRD_Enabled",
                table: "PRODUCTS",
                column: "PRD_Enabled");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PRD_Id",
                table: "PRODUCTS",
                column: "PRD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PRD_Name",
                table: "PRODUCTS",
                column: "PRD_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PRD_Price",
                table: "PRODUCTS",
                column: "PRD_Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");
        }
    }
}
