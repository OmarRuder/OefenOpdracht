using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class ImgNameIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgNaam",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgNaam",
                table: "AspNetUsers");
        }
    }
}
