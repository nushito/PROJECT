using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT.Data.Migrations
{
    public partial class ProductSpecificationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "ProductSpecifications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Income",
                table: "ProductSpecifications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "ProductSpecifications");

            migrationBuilder.DropColumn(
                name: "Income",
                table: "ProductSpecifications");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

          
            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
