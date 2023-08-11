using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "oi_amount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "oi_productid",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "oi_amount", "o_createddate", "oi_productid" },
                values: new object[] { 55, new DateTime(2023, 8, 11, 5, 27, 17, 215, DateTimeKind.Utc).AddTicks(1851), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oi_amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "oi_productid",
                table: "Orders");

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
                table: "OrderItems",
                columns: new[] { "id", "oi_amount", "oi_orderid", "oi_productid" },
                values: new object[,]
                {
                    { 1, 5, 1, 1 },
                    { 2, 15, 1, 2 },
                    { 3, 30, 1, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                column: "o_createddate",
                value: new DateTime(2023, 8, 10, 12, 14, 52, 921, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_oi_orderid",
                table: "OrderItems",
                column: "oi_orderid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_oi_productid",
                table: "OrderItems",
                column: "oi_productid");
        }
    }
}
