using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class vakHasDataresultaatHasDatagroepVakHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vak",
                columns: new[] { "Id", "Naam", "Vakcode" },
                values: new object[,]
                {
                    { 1, "Engels", "EN" },
                    { 2, "Wiskunde", "WI" },
                    { 3, "C# Programmeren", "PRG1" },
                    { 4, "Nederlands", "NE" }
                });

            migrationBuilder.InsertData(
                table: "GroepVak",
                columns: new[] { "GroepId", "VakId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 3, 4 },
                    { 2, 4 },
                    { 1, 4 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 4 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Resultaat",
                columns: new[] { "Id", "Beoordeling", "StudentId", "VakId" },
                values: new object[,]
                {
                    { 7, 9.5, 6, 3 },
                    { 2, 8.4000000000000004, 1, 2 },
                    { 6, 3.3999999999999999, 5, 1 },
                    { 4, 6.4000000000000004, 3, 1 },
                    { 1, 7.5, 1, 1 },
                    { 3, 6.4000000000000004, 1, 3 },
                    { 5, 9.5, 3, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GroepVak",
                keyColumns: new[] { "GroepId", "VakId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
