using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT.Data.Migrations
{
    public partial class ProductSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankExpenses",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cubic",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomsExpenses",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Duty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pieces",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TerminalCharges",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TransportCost",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pieces = table.Column<int>(type: "int", nullable: false),
                    Cubic = table.Column<decimal>(type: "decimal", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    TransportCost = table.Column<decimal>(type: "decimal", nullable: false),
                    TerminalCharges = table.Column<decimal>(type: "decimal", nullable: false),
                    CustomsExpenses = table.Column<decimal>(type: "decimal", nullable: false),
                    Duty = table.Column<decimal>(type: "decimal", nullable: false),
                    BankExpenses = table.Column<decimal>(type: "decimal", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_ProductId",
                table: "ProductSpecifications",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.AddColumn<decimal>(
                name: "BankExpenses",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cubic",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomsExpenses",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Duty",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Pieces",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TerminalCharges",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TransportCost",
                table: "Products",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
