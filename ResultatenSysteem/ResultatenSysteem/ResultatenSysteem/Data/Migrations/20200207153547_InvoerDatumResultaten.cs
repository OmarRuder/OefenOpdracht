using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class InvoerDatumResultaten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InvoerDatum",
                table: "Resultaat",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 772, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 35, 46, 774, DateTimeKind.Local).AddTicks(443));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoerDatum",
                table: "Resultaat");
        }
    }
}
