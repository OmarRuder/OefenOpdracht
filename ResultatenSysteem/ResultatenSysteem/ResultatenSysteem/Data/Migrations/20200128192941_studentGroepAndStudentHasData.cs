using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class studentGroepAndStudentHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groep",
                keyColumn: "Id",
                keyValue: 2,
                column: "Groepscode",
                value: "017AO-B");

            migrationBuilder.InsertData(
                table: "Groep",
                columns: new[] { "Id", "Groepscode", "Naam" },
                values: new object[,]
                {
                    { 3, "017SMW-A", "Sociaal/maatschappelijk-medewerker" },
                    { 4, "017SMW-B", "Sociaal/maatschappelijk-medewerker" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Achternaam", "Studentnummer", "Tussenvoegsel", "Voornaam" },
                values: new object[,]
                {
                    { 3, "Ruder", null, null, "Ruben" },
                    { 4, "Goodreid", null, null, "Tremaine" },
                    { 5, "Stiles", null, null, "Douglass" },
                    { 6, "Blackford", null, null, "Becky" }
                });

            migrationBuilder.InsertData(
                table: "StudentGroep",
                columns: new[] { "StudentId", "GroepId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentGroep",
                columns: new[] { "StudentId", "GroepId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 1, 4 },
                    { 3, 3 },
                    { 4, 2 },
                    { 5, 3 },
                    { 5, 1 },
                    { 6, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "StudentGroep",
                keyColumns: new[] { "StudentId", "GroepId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Groep",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groep",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Groep",
                keyColumn: "Id",
                keyValue: 2,
                column: "Groepscode",
                value: "017AO-A");
        }
    }
}
