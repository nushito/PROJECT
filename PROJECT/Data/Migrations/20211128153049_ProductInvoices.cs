using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT.Data.Migrations
{
    public partial class ProductInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Products_ProductId",
                table: "ProductInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchase_Products_ProductId",
                table: "ProductPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchase_Purchases_PurchaseId",
                table: "ProductPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPurchase",
                table: "ProductPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInvoice",
                table: "ProductInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ProductInvoice_InvoiceId",
                table: "ProductInvoice");

            migrationBuilder.RenameTable(
                name: "ProductPurchase",
                newName: "ProductPurchases");

            migrationBuilder.RenameTable(
                name: "ProductInvoice",
                newName: "ProductInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPurchase_PurchaseId",
                table: "ProductPurchases",
                newName: "IX_ProductPurchases_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPurchases",
                table: "ProductPurchases",
                columns: new[] { "ProductId", "PurchaseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInvoices",
                table: "ProductInvoices",
                columns: new[] { "InvoiceId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoices_ProductId",
                table: "ProductInvoices",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoices_Invoices_InvoiceId",
                table: "ProductInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoices_Products_ProductId",
                table: "ProductInvoices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchases_Products_ProductId",
                table: "ProductPurchases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchases_Purchases_PurchaseId",
                table: "ProductPurchases",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoices_Invoices_InvoiceId",
                table: "ProductInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoices_Products_ProductId",
                table: "ProductInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchases_Products_ProductId",
                table: "ProductPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchases_Purchases_PurchaseId",
                table: "ProductPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPurchases",
                table: "ProductPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInvoices",
                table: "ProductInvoices");

            migrationBuilder.DropIndex(
                name: "IX_ProductInvoices_ProductId",
                table: "ProductInvoices");

            migrationBuilder.RenameTable(
                name: "ProductPurchases",
                newName: "ProductPurchase");

            migrationBuilder.RenameTable(
                name: "ProductInvoices",
                newName: "ProductInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPurchases_PurchaseId",
                table: "ProductPurchase",
                newName: "IX_ProductPurchase_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPurchase",
                table: "ProductPurchase",
                columns: new[] { "ProductId", "PurchaseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInvoice",
                table: "ProductInvoice",
                columns: new[] { "ProductId", "InvoiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoice_InvoiceId",
                table: "ProductInvoice",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Products_ProductId",
                table: "ProductInvoice",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchase_Products_ProductId",
                table: "ProductPurchase",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchase_Purchases_PurchaseId",
                table: "ProductPurchase",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
