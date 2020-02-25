using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class OpleidingAanvraag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpleidingAanvraagId",
                table: "Groep",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpleidingAanvraag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voornaam = table.Column<string>(nullable: true),
                    Tussenvoegsel = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Opmerking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpleidingAanvraag", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Groep_OpleidingAanvraagId",
                table: "Groep",
                column: "OpleidingAanvraagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groep_OpleidingAanvraag_OpleidingAanvraagId",
                table: "Groep",
                column: "OpleidingAanvraagId",
                principalTable: "OpleidingAanvraag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groep_OpleidingAanvraag_OpleidingAanvraagId",
                table: "Groep");

            migrationBuilder.DropTable(
                name: "OpleidingAanvraag");

            migrationBuilder.DropIndex(
                name: "IX_Groep_OpleidingAanvraagId",
                table: "Groep");

            migrationBuilder.DropColumn(
                name: "OpleidingAanvraagId",
                table: "Groep");

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
    }
}
