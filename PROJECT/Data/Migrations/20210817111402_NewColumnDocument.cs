using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT.Data.Migrations
{
    public partial class NewColumnDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Clients_ClientId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MyCompanies_MyCompanyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Invoices",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoices",
                newName: "IX_Invoices_SellerId");

            migrationBuilder.AlterColumn<int>(
                name: "MyCompanyId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Clients_ClientId",
                table: "Documents",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MyCompanies_MyCompanyId",
                table: "Documents",
                column: "MyCompanyId",
                principalTable: "MyCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_MyCompanies_SellerId",
                table: "Invoices",
                column: "SellerId",
                principalTable: "MyCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Clients_ClientId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MyCompanies_MyCompanyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_MyCompanies_SellerId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Invoices",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SellerId",
                table: "Invoices",
                newName: "IX_Invoices_SupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "MyCompanyId",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Clients_ClientId",
                table: "Documents",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MyCompanies_MyCompanyId",
                table: "Documents",
                column: "MyCompanyId",
                principalTable: "MyCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
