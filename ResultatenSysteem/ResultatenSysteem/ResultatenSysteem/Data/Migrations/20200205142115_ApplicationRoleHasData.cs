﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class ApplicationRoleHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "4dac0a77-a6fd-49ac-99a0-38ec6332542d", "2cd5c1ee-3474-4100-9f48-37f7680e71bb", "Medewerker van WRX Hogere School", "Medewerker", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "5a419cdb-89d1-4d8a-80f5-7a0720553095", "dc88cee0-0e35-479d-858b-2f010881786c", "Student van WRX Hogere School", "Student", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dac0a77-a6fd-49ac-99a0-38ec6332542d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a419cdb-89d1-4d8a-80f5-7a0720553095");
        }
    }
}
