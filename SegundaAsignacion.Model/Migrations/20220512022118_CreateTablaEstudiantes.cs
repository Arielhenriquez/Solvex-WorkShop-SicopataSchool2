using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegundaAsignacion.Model.Migrations
{
    public partial class CreateTablaEstudiantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    correo = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    contraseña = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creada = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_idestudiante", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
