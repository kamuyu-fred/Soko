using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Soko.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyTransactions",
                columns: table => new
                {
                    BTId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TVendorName = table.Column<string>(type: "TEXT", nullable: false),
                    BTQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    TProductName = table.Column<string>(type: "TEXT", nullable: false),
                    TBuyPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    BuyTransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyTransactions", x => x.BTId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerLocation = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerAddedDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "POSBuy",
                columns: table => new
                {
                    PBTId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PTVendorName = table.Column<string>(type: "TEXT", nullable: false),
                    PBTQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PTProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    PTProductName = table.Column<string>(type: "TEXT", nullable: false),
                    PTBuyPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PBuyTransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSBuy", x => x.PBTId);
                });

            migrationBuilder.CreateTable(
                name: "POSSell",
                columns: table => new
                {
                    PSTId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PTCustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    PSTQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PTProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    PTProductName = table.Column<string>(type: "TEXT", nullable: false),
                    PTSellPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PSellTransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSSell", x => x.PSTId);
                });

            migrationBuilder.CreateTable(
                name: "SellTransactions",
                columns: table => new
                {
                    STId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TCustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    STQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    TProductName = table.Column<string>(type: "TEXT", nullable: false),
                    TSellPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    SellTransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellTransactions", x => x.STId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendorName = table.Column<string>(type: "TEXT", nullable: false),
                    VendorPhone = table.Column<string>(type: "TEXT", nullable: false),
                    VendorLocation = table.Column<string>(type: "TEXT", nullable: false),
                    VendorAddedDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    SellPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Foods" },
                    { 2, "Kitchen" },
                    { 3, "Electronics" },
                    { 4, "Toys" },
                    { 5, "Fruits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyTransactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "POSBuy");

            migrationBuilder.DropTable(
                name: "POSSell");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SellTransactions");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
