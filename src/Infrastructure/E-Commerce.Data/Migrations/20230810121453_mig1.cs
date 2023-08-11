using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    c_lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    c_status = table.Column<short>(type: "smallint", nullable: false),
                    c_email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pc_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pc_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ca_customerid = table.Column<int>(type: "int", nullable: false),
                    ca_addressline1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ca_addressline2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ca_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ca_postalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ca_country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_ca_customerid",
                        column: x => x.ca_customerid,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    o_customerid = table.Column<int>(type: "int", nullable: false),
                    o_createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    o_status = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_o_customerid",
                        column: x => x.o_customerid,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    p_unitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    p_categoryid = table.Column<int>(type: "int", nullable: false),
                    p_currencyid = table.Column<short>(type: "smallint", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_p_categoryid",
                        column: x => x.p_categoryid,
                        principalTable: "ProductCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oi_orderid = table.Column<int>(type: "int", nullable: false),
                    oi_productid = table.Column<int>(type: "int", nullable: false),
                    oi_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_oi_orderid",
                        column: x => x.oi_orderid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_oi_productid",
                        column: x => x.oi_productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "c_email", "c_firstname", "c_lastname", "c_status" },
                values: new object[] { 1, "cagridarici34@icloud.com", "cagri", "darici", (short)1 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "id", "pc_description", "pc_name" },
                values: new object[] { 1, "Cam porselen ve benzeri maddelerden yapılmış olan eşya çeşitlerine Züccaciye denir.", "Züccaciye" });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "id", "ca_addressline1", "ca_addressline2", "ca_city", "ca_country", "ca_customerid", "ca_postalcode" },
                values: new object[] { 1, "0975 Camron Turnpike / Haleighberg 52505", null, "Haleighberg", "Germany", 1, "52505" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "o_createddate", "o_customerid", "o_status", "Status" },
                values: new object[] { 1, new DateTime(2023, 8, 10, 12, 14, 52, 921, DateTimeKind.Utc).AddTicks(3526), 1, (short)0, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "p_categoryid", "Currency", "p_currencyid", "p_name", "p_unitprice" },
                values: new object[,]
                {
                    { 1, 1, 0, (short)0, "Cam Sürahi", 155.55m },
                    { 2, 1, 2, (short)2, "Sepet", 2m },
                    { 3, 1, 1, (short)1, "Bardak", 1m },
                    { 4, 1, 0, (short)0, "Cam Şişe", 12m },
                    { 5, 1, 0, (short)0, "Zigon Sehpa", 254.90m },
                    { 6, 1, 0, (short)0, "Teflon Tava", 365.55m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "id", "oi_amount", "oi_orderid", "oi_productid" },
                values: new object[,]
                {
                    { 1, 5, 1, 1 },
                    { 2, 15, 1, 2 },
                    { 3, 30, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_ca_customerid",
                table: "CustomerAddresses",
                column: "ca_customerid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_oi_orderid",
                table: "OrderItems",
                column: "oi_orderid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_oi_productid",
                table: "OrderItems",
                column: "oi_productid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_o_customerid",
                table: "Orders",
                column: "o_customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_p_categoryid",
                table: "Products",
                column: "p_categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
