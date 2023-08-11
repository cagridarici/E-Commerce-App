using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "oi_productid",
                table: "Orders",
                newName: "o_productid");

            migrationBuilder.RenameColumn(
                name: "oi_amount",
                table: "Orders",
                newName: "o_amount");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                column: "o_createddate",
                value: new DateTime(2023, 8, 11, 6, 27, 24, 277, DateTimeKind.Utc).AddTicks(4993));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_o_productid",
                table: "Orders",
                column: "o_productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_o_productid",
                table: "Orders",
                column: "o_productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_o_productid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_o_productid",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "o_productid",
                table: "Orders",
                newName: "oi_productid");

            migrationBuilder.RenameColumn(
                name: "o_amount",
                table: "Orders",
                newName: "oi_amount");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "o_createddate", "Status" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 27, 17, 215, DateTimeKind.Utc).AddTicks(1851), 0 });
        }
    }
}
