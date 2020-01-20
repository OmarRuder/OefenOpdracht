using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultatenSysteem.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: false),
                    Groepscode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voornaam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Tussenvoegsel = table.Column<string>(nullable: true),
                    Studentnummer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: false),
                    Vakcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroep",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    GroepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroep", x => new { x.StudentId, x.GroepId });
                    table.ForeignKey(
                        name: "FK_StudentGroep_Groep_GroepId",
                        column: x => x.GroepId,
                        principalTable: "Groep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroep_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroepVak",
                columns: table => new
                {
                    GroepId = table.Column<int>(nullable: false),
                    VakId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroepVak", x => new { x.GroepId, x.VakId });
                    table.ForeignKey(
                        name: "FK_GroepVak_Groep_GroepId",
                        column: x => x.GroepId,
                        principalTable: "Groep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroepVak_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultaat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Beoordeling = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    VakId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultaat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultaat_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultaat_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroepVak_VakId",
                table: "GroepVak",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultaat_StudentId",
                table: "Resultaat",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultaat_VakId",
                table: "Resultaat",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroep_GroepId",
                table: "StudentGroep",
                column: "GroepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroepVak");

            migrationBuilder.DropTable(
                name: "Resultaat");

            migrationBuilder.DropTable(
                name: "StudentGroep");

            migrationBuilder.DropTable(
                name: "Vak");

            migrationBuilder.DropTable(
                name: "Groep");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
