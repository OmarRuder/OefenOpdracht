using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class Opleidingopleiding-aanvragen_aanvraag-status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "opleiding-aanvragen_aanvraag-status",
                table: "OpleidingAanvraag",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opleiding-aanvragen_aanvraag-status",
                table: "OpleidingAanvraag");

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 754, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoerDatum",
                value: new DateTime(2020, 2, 7, 16, 57, 1, 756, DateTimeKind.Local).AddTicks(3834));
        }
    }
}
