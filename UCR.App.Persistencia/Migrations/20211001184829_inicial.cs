using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCR.App.Persistencia.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aforo = table.Column<int>(type: "int", nullable: false),
                    numeroMesas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<int>(type: "int", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    estadoCovid = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restauranteid = table.Column<int>(type: "int", nullable: true),
                    dependencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oficina = table.Column<int>(type: "int", nullable: true),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cubiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurnoTrabajo = table.Column<int>(type: "int", nullable: true),
                    PersonalCocina_TurnoTrabajo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personas_Restaurante_Restauranteid",
                        column: x => x.Restauranteid,
                        principalTable: "Restaurante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turnos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Restauranteid",
                table: "Personas",
                column: "Restauranteid");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PersonaId",
                table: "Turnos",
                column: "PersonaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Restaurante");
        }
    }
}
