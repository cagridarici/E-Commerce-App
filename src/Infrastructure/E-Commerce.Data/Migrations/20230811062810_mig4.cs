using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    i_orderid = table.Column<int>(type: "int", nullable: false),
                    i_invoicenumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    i_invoicedate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_i_orderid",
                        column: x => x.i_orderid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                column: "o_createddate",
                value: new DateTime(2023, 8, 11, 6, 28, 10, 509, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_i_orderid",
                table: "Invoices",
                column: "i_orderid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                column: "o_createddate",
                value: new DateTime(2023, 8, 11, 6, 27, 24, 277, DateTimeKind.Utc).AddTicks(4993));
        }
    }
}
