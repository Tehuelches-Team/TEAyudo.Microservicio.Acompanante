
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecialidadId);
                });

 
            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    ObraSocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.ObraSocialId);
                });

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
                    DisponibilidadSemanalId = table.Column<int>(type: "int", nullable: false)
                });

            migrationBuilder.CreateTable(
                name: "AcompananteEspecialidad",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompananteEspecialidad", x => new { x.AcompananteId, x.EspecialidadId });
                    table.ForeignKey(
                        name: "FK_AcompananteEspecialidad_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcompananteEspecialidad_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcompananteObraSocial",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    ObrasocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompananteObraSocial", x => new { x.AcompananteId, x.ObrasocialId });
                    table.ForeignKey(
                        name: "FK_AcompananteObraSocial_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompananteObraSocial_ObrasSociales_ObrasocialId",
                        column: x => x.ObrasocialId,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisponibilidadesSemanales",
                columns: table => new
                {
                    DisponibilidadSemanalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadesSemanales", x => x.DisponibilidadSemanalId);
                    table.ForeignKey(
                        name: "FK_DisponibilidadesSemanales_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcompananteEspecialidad_EspecialidadId",
                table: "AcompananteEspecialidad",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_AcompananteObraSocial_ObrasocialId",
                table: "AcompananteObraSocial",
                column: "ObrasocialId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadesSemanales_AcompananteId",
                table: "DisponibilidadesSemanales",
                column: "AcompananteId");

            migrationBuilder.InsertData(
                table: "ObrasSociales", // Nombre de la tabla
                columns: new[] { "Nombre", "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[,]
                {
                                    { "OSDE", "Obra Social De Empresarios" },
                                    { "IOMA", "I O M A" }
                });

            migrationBuilder.InsertData(
                table: "Especialidades", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Acompañante Terapeutico" });

            migrationBuilder.InsertData(
                table: "Especialidades", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Acompañante Escolar" });

            //migrationBuilder.InsertData(
            //    table: "DisponibilidadSemanal",
            //    columns: new[] { "DiaSemana", "HorarioInicio", "HoraFin" },
            //    values: new object[]
            //    {
            //        1,
            //        "08:00:00",
            //        "15:00:00"});

            //migrationBuilder.InsertData(
            //    table: "DisponibilidadSemanal",
            //    columns: new[] { "DiaSemana", "HorarioInicio", "HoraFin" },
            //    values: new object[]
            //   {
            //        2,
            //        "09:00:00",
            //        "15:00:00"});


            //migrationBuilder.InsertData(
            //   table: "Acompanantes",
            //   columns: new[] { "ZonaLaboral", "ObraSocialId", "Contacto", "Documentacion", "EspecialidadId", "Experiencia", "UsuarioId", "DisponibilidadSemanalId" },
            //   values: new object[] {  "Florencio Varela",
            //                            "1",
            //                            "1550112233" ,
            //                            "/user/doc/cv.docx" ,
            //                            "1" ,
            //                            "string",
            //                            "1",
            //                            "1" });
            //migrationBuilder.InsertData(
            //   table: "Acompanantes",
            //   columns: new[] { "ZonaLaboral", "ObraSocialId", "Contacto", "Documentacion", "EspecialidadId", "Experiencia", "UsuarioId", "DisponibilidadSemanalId" },
            //   values: new object[] {  "Florencio Varela",
            //                            "2",
            //                            "1550223344" ,
            //                            "/user/doc/cv.docx" ,
            //                            "1" ,
            //                            "string",
            //                            "2",
            //                            "1" });

        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompananteEspecialidad");

            migrationBuilder.DropTable(
                name: "AcompananteObraSocial");

            migrationBuilder.DropTable(
                name: "DisponibilidadesSemanales");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ObrasSociales");

            migrationBuilder.DropTable(
                name: "Acompanante");
            }
    }
}
