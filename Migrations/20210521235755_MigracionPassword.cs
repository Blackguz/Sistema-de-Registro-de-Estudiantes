using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_Registro_de_Estudiantes.Migrations
{
    public partial class MigracionPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUMNO",
                columns: table => new
                {
                    MATRICULA = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NOMBRE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    APATERNO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AMATERNO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TELEFONO = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    GRUPO = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    SEMESTRE = table.Column<int>(type: "int", nullable: false),
                    CARRERA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FOTO = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALUMNO__46A2F689436D64CC", x => x.MATRICULA);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_USUARIO",
                columns: table => new
                {
                    ID_TIPO_USUARIO = table.Column<int>(type: "int", nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TIPO_USU__85A05968EBFAFB0C", x => x.ID_TIPO_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false),
                    NOMUSUARIO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PASSUSUARIO = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIOS__91136B905C695911", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "LOCALIZACION",
                columns: table => new
                {
                    ID_LOC = table.Column<int>(type: "int", nullable: false),
                    MATRICULA = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    LOCALIDAD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CIUDAD_ORIGEN = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    COLONIA = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CALLE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CODIGO_POSTAL = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOCALIZA__447915F14E4BA82F", x => new { x.MATRICULA, x.ID_LOC });
                    table.ForeignKey(
                        name: "FK__LOCALIZAC__MATRI__2C3393D0",
                        column: x => x.MATRICULA,
                        principalTable: "ALUMNO",
                        principalColumn: "MATRICULA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MIS_DOCUMENTOS",
                columns: table => new
                {
                    MATRICULA = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    ID_DOCS = table.Column<int>(type: "int", nullable: false),
                    RFC = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ACTA_NACIMIENTO = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CURP = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MIS_DOCU__83FE26C026434F67", x => new { x.MATRICULA, x.ID_DOCS });
                    table.ForeignKey(
                        name: "FK__MIS_DOCUM__MATRI__2F10007B",
                        column: x => x.MATRICULA,
                        principalTable: "ALUMNO",
                        principalColumn: "MATRICULA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__ALUMNO__D6F16945FE19B0CC",
                table: "ALUMNO",
                column: "TELEFONO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__USUARIOS__EC0C1624428FC520",
                table: "USUARIOS",
                column: "NOMUSUARIO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOCALIZACION");

            migrationBuilder.DropTable(
                name: "MIS_DOCUMENTOS");

            migrationBuilder.DropTable(
                name: "TIPO_USUARIO");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "ALUMNO");
        }
    }
}
