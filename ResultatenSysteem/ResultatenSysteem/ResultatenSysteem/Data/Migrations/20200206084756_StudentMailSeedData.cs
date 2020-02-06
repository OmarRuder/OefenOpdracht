using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class StudentMailSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "VakId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Studentnummer" },
                values: new object[] { "omarruder@wrx.hgs", "140553" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "issyruder@wrx.sdt");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Achternaam", "Email", "Voornaam" },
                values: new object[] { "Bruins", "wiibebruins@wrx.sdt", "Wiibe" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Achternaam", "Email", "Studentnummer", "Voornaam" },
                values: new object[] { "Otay", "othmanotay@wrx.sdt", "134902", "Othman" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Achternaam", "Email", "Voornaam" },
                values: new object[] { "Rafik", "zahirarafik@wrx.sdt", "Zahira" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Achternaam", "Email", "Studentnummer", "Voornaam" },
                values: new object[] { "Roeder", "daveroeder@wrx.sdt", "drA231", "Dave" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Achternaam", "Email", "Studentnummer", "Tussenvoegsel", "Voornaam" },
                values: new object[,]
                {
                    { 7, "Vlaar", "lesleyvlaar@wrx.sdt", "691420", null, "Lesley" },
                    { 8, "Bijl", "jannobijl@wrx.sdt", "132431", null, "Janno" }
                });

            migrationBuilder.InsertData(
                table: "Resultaat",
                columns: new[] { "Id", "Beoordeling", "StudentId", "VakId" },
                values: new object[,]
                {
                    { 8, 4.2999999999999998, 7, 3 },
                    { 9, 5.5, 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "StudentGroep",
                columns: new[] { "StudentId", "GroepId" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 7, 4 },
                    { 8, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Resultaat",
                keyColumn: "Id",
                keyValue: 7,
                column: "VakId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Studentnummer" },
                values: new object[] { null, "123054" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Achternaam", "Email", "Voornaam" },
                values: new object[] { "Ruder", null, "Ruben" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Achternaam", "Email", "Studentnummer", "Voornaam" },
                values: new object[] { "Goodreid", null, "236789", "Tremaine" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Achternaam", "Email", "Voornaam" },
                values: new object[] { "Stiles", null, "Douglass" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Achternaam", "Email", "Studentnummer", "Voornaam" },
                values: new object[] { "Blackford", null, "140443", "Becky" });
        }
    }
}
