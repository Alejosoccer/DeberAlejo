using Microsoft.EntityFrameworkCore.Migrations;

namespace AlejandroDeber.Migrations
{
    public partial class Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: true),
                    LavadoraId = table.Column<int>(nullable: true),
                    NeveraId = table.Column<int>(nullable: true),
                    TelevisionId = table.Column<int>(nullable: true),
                    TabletId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lavadora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lavadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lavadora_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Microonda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microonda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Microonda_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nevera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nevera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nevera_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Televison",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Televison", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Televison_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lavadora_PersonaId",
                table: "Lavadora",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Microonda_PersonaId",
                table: "Microonda",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nevera_PersonaId",
                table: "Nevera",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LavadoraId",
                table: "Persona",
                column: "LavadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_NeveraId",
                table: "Persona",
                column: "NeveraId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TabletId",
                table: "Persona",
                column: "TabletId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TelevisionId",
                table: "Persona",
                column: "TelevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Televison_PersonaId",
                table: "Televison",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Lavadora_LavadoraId",
                table: "Persona",
                column: "LavadoraId",
                principalTable: "Lavadora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Nevera_NeveraId",
                table: "Persona",
                column: "NeveraId",
                principalTable: "Nevera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Microonda_TabletId",
                table: "Persona",
                column: "TabletId",
                principalTable: "Microonda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Televison_TelevisionId",
                table: "Persona",
                column: "TelevisionId",
                principalTable: "Televison",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lavadora_Persona_PersonaId",
                table: "Lavadora");

            migrationBuilder.DropForeignKey(
                name: "FK_Microonda_Persona_PersonaId",
                table: "Microonda");

            migrationBuilder.DropForeignKey(
                name: "FK_Nevera_Persona_PersonaId",
                table: "Nevera");

            migrationBuilder.DropForeignKey(
                name: "FK_Televison_Persona_PersonaId",
                table: "Televison");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Lavadora");

            migrationBuilder.DropTable(
                name: "Nevera");

            migrationBuilder.DropTable(
                name: "Microonda");

            migrationBuilder.DropTable(
                name: "Televison");
        }
    }
}
