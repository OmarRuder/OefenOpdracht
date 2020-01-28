using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class modelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groep",
                columns: new[] { "Id", "Groepscode", "Naam" },
                values: new object[,]
                {
                    { 1, "017AO-A", "Applicatie/media-ontwikkelaar" },
                    { 2, "017AO-A", "Applicatie/media-ontwikkelaar" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Achternaam", "Studentnummer", "Tussenvoegsel", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Ruder", null, null, "Omar" },
                    { 2, "Ruder", null, null, "Issy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groep",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groep",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
