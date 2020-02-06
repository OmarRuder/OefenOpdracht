using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class ApplicationUserNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b26cf1d-b869-43bc-85cd-30e33ef83c59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d287078-7753-4224-b77e-6d2b75ba3583");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c654d7fb-c169-40e7-93e8-fffb3ce8b98c", "afb8e518-4fe4-4b9c-9e72-d14f12b8eb21", "Medewerker van WRX Hogere School", "Medewerker", null },
                    { "ad4b9aee-bff4-4f00-93ae-dbbeb7e4c654", "29cdff1e-e3bb-476d-9ae1-b3c44a3caa3d", "Student van WRX Hogere School", "Student", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Achternaam", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gebruikersnummer", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Tussenvoegsel", "TwoFactorEnabled", "UserName", "Voornaam" },
                values: new object[,]
                {
                    { "22c83364-97b1-49c2-b5a3-1a0636f58734", 0, "Verwacht", "cfe1ad0d-11b1-4234-8403-017b5ffe4c0f", "hadverwacht@wrx.sdt", false, "210312", false, null, null, null, null, null, false, null, "", false, "hadverwacht@wrx.sdt", "Had" },
                    { "b603e36c-17ac-4047-af6d-507b4a89f96c", 0, "Bruins", "727f0e9c-5fa1-412c-afd5-478af7fdb9ec", "wiibebruins@wrx.sdt", false, "003221", false, null, null, null, null, null, false, null, "", false, "wiibebruins@wrx.sdt", "Wiibe" },
                    { "e88004ec-c94e-4431-9fec-63177c43efa4", 0, "Otay", "72211069-0d69-4bfc-8aee-2ff4d65f3988", "othmanotay@wrx.sdt", false, "134902", false, null, null, null, null, null, false, null, "", false, "othmanotay@wrx.sdt", "Othman" },
                    { "82508b4b-1ee3-49f2-b10b-7e4d9405f1ca", 0, "Rafik", "a3592463-b4e6-4840-b2af-839282b0cc5f", "zahirarafik@wrx.sdt", false, "902134", false, null, null, null, null, null, false, null, "", false, "zahirarafik@wrx.sdt", "Zahira" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad4b9aee-bff4-4f00-93ae-dbbeb7e4c654");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c654d7fb-c169-40e7-93e8-fffb3ce8b98c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c83364-97b1-49c2-b5a3-1a0636f58734");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82508b4b-1ee3-49f2-b10b-7e4d9405f1ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b603e36c-17ac-4047-af6d-507b4a89f96c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e88004ec-c94e-4431-9fec-63177c43efa4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "3d287078-7753-4224-b77e-6d2b75ba3583", "e801a7bc-7866-4d05-bc7e-7fb811cb1fff", "Medewerker van WRX Hogere School", "Medewerker", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "3b26cf1d-b869-43bc-85cd-30e33ef83c59", "2e53918d-0f53-4fae-b006-91cc134480b4", "Student van WRX Hogere School", "Student", null });
        }
    }
}
