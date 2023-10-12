﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEAyudo_Acompanantes;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(TEAyudoContext))]
    partial class TEAyudoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TEAyudo_Acompanantes.Acompanante", b =>
                {
                    b.Property<int>("AcompananteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcompananteId"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisponibilidadSemanalId")
                        .HasColumnType("int");

                    b.Property<string>("Documentacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("Experiencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObraSocialId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("ZonaLaboral")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcompananteId");

                    b.ToTable("Acompanante", (string)null);
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.AcompananteEspecialidad", b =>
                {
                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.HasKey("AcompananteId", "EspecialidadId");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("AcompanantesEspecialidades");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.AcompananteObraSocial", b =>
                {
                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("ObrasocialId")
                        .HasColumnType("int");

                    b.HasKey("AcompananteId", "ObrasocialId");

                    b.HasIndex("ObrasocialId");

                    b.ToTable("AcompanantesObraSocial");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.DisponibilidadSemanal", b =>
                {
                    b.Property<int>("DisponibilidadSemanalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisponibilidadSemanalId"));

                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HorarioFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time");

                    b.HasKey("DisponibilidadSemanalId");

                    b.HasIndex("AcompananteId");

                    b.ToTable("DisponibilidadSemanal", (string)null);
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.Especialidad", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EspecialidadId");

                    b.ToTable("Especialidad", (string)null);
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.ObraSocial", b =>
                {
                    b.Property<int>("ObraSocialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObraSocialId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObraSocialId");

                    b.ToTable("ObraSocial", (string)null);
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.AcompananteEspecialidad", b =>
                {
                    b.HasOne("TEAyudo_Acompanantes.Acompanante", "Acompanante")
                        .WithMany("Especialidades")
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEAyudo_Acompanantes.Especialidad", "Especialidad")
                        .WithMany("Acompanantes")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanante");

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.AcompananteObraSocial", b =>
                {
                    b.HasOne("TEAyudo_Acompanantes.Acompanante", "Acompanante")
                        .WithMany("ObrasSociales")
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEAyudo_Acompanantes.ObraSocial", "ObraSocial")
                        .WithMany("Acompanantes")
                        .HasForeignKey("ObrasocialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanante");

                    b.Navigation("ObraSocial");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.DisponibilidadSemanal", b =>
                {
                    b.HasOne("TEAyudo_Acompanantes.Acompanante", "Acompanante")
                        .WithMany("DisponibilidadesSemanales")
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanante");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.Acompanante", b =>
                {
                    b.Navigation("DisponibilidadesSemanales");

                    b.Navigation("Especialidades");

                    b.Navigation("ObrasSociales");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.Especialidad", b =>
                {
                    b.Navigation("Acompanantes");
                });

            modelBuilder.Entity("TEAyudo_Acompanantes.ObraSocial", b =>
                {
                    b.Navigation("Acompanantes");
                });
#pragma warning restore 612, 618
        }
    }
}
