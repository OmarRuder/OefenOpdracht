using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class ChosenThemeIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChosenTheme",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 877, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 14, 12, 10, 52, 880, DateTimeKind.Local).AddTicks(6052));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenTheme",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 499, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 9, 21, 10, 500, DateTimeKind.Local).AddTicks(5927));
        }
    }
}
