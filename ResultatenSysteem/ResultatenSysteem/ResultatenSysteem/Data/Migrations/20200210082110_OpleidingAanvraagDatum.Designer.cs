using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class OpleidingAanvraag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AanvraagDatum",
                table: "OpleidingAanvraag",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AanvraagDatum",
                table: "OpleidingAanvraag");

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 89, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 10, 8, 51, 54, 91, DateTimeKind.Local).AddTicks(6452));
        }
    }
}
