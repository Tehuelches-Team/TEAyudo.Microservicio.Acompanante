using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acompanante",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ZonaLaboral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObraSocialId = table.Column<int>(type: "int", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilidad = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompanante", x => x.AcompananteId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.EspecialidadId);
                });

            migrationBuilder.CreateTable(
                name: "ObraSocial",
                columns: table => new
                {
                    ObraSocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraSocial", x => x.ObraSocialId);
                });

            migrationBuilder.CreateTable(
                name: "AcompanantesEspecialidades",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanantesEspecialidades", x => new { x.AcompananteId, x.EspecialidadId });
                    table.ForeignKey(
                        name: "FK_AcompanantesEspecialidades_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompanantesEspecialidades_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcompanantesObraSocial",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    ObrasocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanantesObraSocial", x => new { x.AcompananteId, x.ObrasocialId });
                    table.ForeignKey(
                        name: "FK_AcompanantesObraSocial_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompanantesObraSocial_ObraSocial_ObrasocialId",
                        column: x => x.ObrasocialId,
                        principalTable: "ObraSocial",
                        principalColumn: "ObraSocialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Especialidad",
                columns: new[] { "EspecialidadId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Acompañamiento Escolar" },
                    { 2, "Cuidado domiciliario" }
                });

            migrationBuilder.InsertData(
                table: "ObraSocial",
                columns: new[] { "ObraSocialId", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Obra Social de Empresas", "OSDE" },
                    { 2, "Obra Social de Empresas", "Swiss Medical" },
                    { 3, "Obra Social de Empresas", "Galeno" },
                    { 4, "Obra Social de Empresas", "Medicus" },
                    { 5, "Obra Social de Empresas", "OSDEPYM" },
                    { 6, "Obra Social de Empresas", "OSPE" },
                    { 7, "Obra Social de Empresas", "OSSEG" },
                    { 8, "Obra Social de Empresas", "OSUT" },
                    { 9, "Obra Social de Empresas", "OSUTHGRA" },
                    { 10, "Obra Social de Empresas", "OSFFENTOS" },
                    { 11, "Obra Social de Empresas", "OSFATUN" },
                    { 12, "Obra Social de Empresas", "OSPEPBA" },
                    { 13, "Obra Social de Empresas", "OSPSA" },
                    { 14, "Obra Social de Empresas", "OSPS" },
                    { 15, "Obra Social de Empresas", "OSPIA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcompanantesEspecialidades_EspecialidadId",
                table: "AcompanantesEspecialidades",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_AcompanantesObraSocial_ObrasocialId",
                table: "AcompanantesObraSocial",
                column: "ObrasocialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompanantesEspecialidades");

            migrationBuilder.DropTable(
                name: "AcompanantesObraSocial");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Acompanante");

            migrationBuilder.DropTable(
                name: "ObraSocial");
        }
    }
}
