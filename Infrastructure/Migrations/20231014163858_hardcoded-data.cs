using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class hardcodeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidad",
                columns: new[] { "EspecialidadId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Acompañamiento Escolar Matutino" },
                    { 2, "Cuidado hogareño matutino" },
                    { 3, "Cuidado hogareñoa vespertino" },
                    { 4, "Cuidado hogareño fines de semana" },
                    { 5, "Acompañamiento escolar vespertino" },
                    { 6, "Acompañamiento actividad deportiva" },
                    { 7, "Acompañamoento especial eventual" },
                    { 8, "Cuidado de Personas con Parkinson" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Especialidad",
                keyColumn: "EspecialidadId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ObraSocial",
                keyColumn: "ObraSocialId",
                keyValue: 15);
        }
    }
}
