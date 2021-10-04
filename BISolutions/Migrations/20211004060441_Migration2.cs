using Microsoft.EntityFrameworkCore.Migrations;

namespace BISolutions.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Reporte",
                schema: "dbo",
                columns: table => new
                {
                    reporte_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reporte_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reporte_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reporte_activo = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.reporte_id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "dbo",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "Reporte_Rol",
                schema: "dbo",
                columns: table => new
                {
                    reporte_rol_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol_id = table.Column<int>(type: "int", nullable: false),
                    reporte_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte_Rol", x => x.reporte_rol_id);
                    table.ForeignKey(
                        name: "FK_Reporte_Rol_Reporte_reporte_id",
                        column: x => x.reporte_id,
                        principalSchema: "dbo",
                        principalTable: "Reporte",
                        principalColumn: "reporte_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reporte_Rol_Rol_rol_id",
                        column: x => x.rol_id,
                        principalSchema: "dbo",
                        principalTable: "Rol",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario_correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario_contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario_sal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario_rol_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_usuario_rol_id",
                        column: x => x.usuario_rol_id,
                        principalSchema: "dbo",
                        principalTable: "Rol",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Rol_reporte_id",
                schema: "dbo",
                table: "Reporte_Rol",
                column: "reporte_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Rol_rol_id",
                schema: "dbo",
                table: "Reporte_Rol",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_usuario_rol_id",
                schema: "dbo",
                table: "Usuario",
                column: "usuario_rol_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reporte_Rol",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Reporte",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "dbo");
        }
    }
}
