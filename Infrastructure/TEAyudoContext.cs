﻿
using Microsoft.EntityFrameworkCore;

namespace TEAyudo_Acompanantes;
public class TEAyudoContext : DbContext
{
    public DbSet<Acompanante> Acompanantes { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<ObraSocial> ObrasSociales { get; set; }
    public DbSet<AcompananteEspecialidad> AcompanantesEspecialidades { get; set; }
    public DbSet<AcompananteObraSocial> AcompanantesObraSocial { get; set; }
    public DbSet<DisponibilidadSemanal> DisponibilidadesSemanales { get; set; }

    public TEAyudoContext(DbContextOptions<TEAyudoContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.ToTable("Acompanante");
            entity.HasKey(a => a.AcompananteId);
            entity.Property(a => a.AcompananteId).ValueGeneratedOnAdd().IsRequired();
            entity.HasMany<DisponibilidadSemanal>(a => a.DisponibilidadesSemanales)
            .WithOne(ds => ds.Acompanante)
            .HasForeignKey(ds => ds.AcompananteId)
            .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany<AcompananteEspecialidad>(a => a.Especialidades)
           .WithOne(ds => ds.Acompanante)
           .HasForeignKey(ds => ds.AcompananteId)
           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany<AcompananteObraSocial>(a => a.ObrasSociales)
            .WithOne(ds => ds.Acompanante)
            .HasForeignKey(ds => ds.AcompananteId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<AcompananteEspecialidad>(entity => 
        { 
            entity.HasKey(a => new { a.AcompananteId, a.EspecialidadId });
            entity.HasOne<Acompanante>(s => s.Acompanante)
            .WithMany(s => s.Especialidades)
            .HasForeignKey(s => s.AcompananteId);
            entity.HasOne<Especialidad>(s => s.Especialidad)
            .WithMany(s => s.Acompanantes)
            .HasForeignKey(s => s.EspecialidadId);
        });

        modelBuilder.Entity<AcompananteObraSocial>(entity =>
        {
            entity.HasKey(a => new { a.AcompananteId, a.ObrasocialId });
            entity.HasOne<Acompanante>(s => s.Acompanante)
            .WithMany(s => s.ObrasSociales)
            .HasForeignKey(s => s.AcompananteId);
            entity.HasOne<ObraSocial>(s => s.ObraSocial)
            .WithMany(s => s.Acompanantes)
            .HasForeignKey(s => s.ObrasocialId);
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.ToTable("Especialidad");
            entity.HasKey(d => d.EspecialidadId);
            entity.HasMany<AcompananteEspecialidad>(s => s.Acompanantes)
            .WithOne(s => s.Especialidad)
            .HasForeignKey(s => s.EspecialidadId)
            .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<ObraSocial>(entity =>
        {
            entity.ToTable("ObraSocial");
            entity.HasKey(d => d.ObraSocialId);
            entity.HasMany<AcompananteObraSocial>(s => s.Acompanantes)
            .WithOne(s => s.ObraSocial)
            .HasForeignKey(s => s.ObrasocialId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DisponibilidadSemanal>(entity =>
        {
            entity.ToTable("DisponibilidadSemanal");
            entity.HasKey(d => d.DisponibilidadSemanalId);
            entity.HasOne<Acompanante>(s => s.Acompanante)
            .WithMany(s => s.DisponibilidadesSemanales)
            .HasForeignKey(s => s.AcompananteId)
            .OnDelete(DeleteBehavior.Cascade);
        });



        modelBuilder.Entity<ObraSocial>().HasData(
            new ObraSocial { ObraSocialId = 1, Nombre = "OSDE", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 2, Nombre = "Swiss Medical", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 3, Nombre = "Galeno", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 4, Nombre = "Medicus", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 5, Nombre = "OSDEPYM", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 6, Nombre = "OSPE", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 7, Nombre = "OSSEG", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 8, Nombre = "OSUT", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 9, Nombre = "OSUTHGRA", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 10, Nombre = "OSFFENTOS", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 11, Nombre = "OSFATUN", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 12, Nombre = "OSPEPBA", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 13, Nombre = "OSPSA", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 14, Nombre = "OSPS", Descripcion = "Obra Social de Empresas" },
            new ObraSocial { ObraSocialId = 15, Nombre = "OSPIA", Descripcion = "Obra Social de Empresas" }                       
        );

        modelBuilder.Entity<Especialidad>().HasData(
            
            new Especialidad { EspecialidadId = 1, Descripcion = "Acompañamiento Escolar Matutino" },
            new Especialidad { EspecialidadId = 2, Descripcion = "Cuidado hogareño matutino" },
            new Especialidad { EspecialidadId = 3, Descripcion = "Cuidado hogareñoa vespertino" },
            new Especialidad { EspecialidadId = 4, Descripcion = "Cuidado hogareño fines de semana" },
            new Especialidad { EspecialidadId = 5, Descripcion = "Acompañamiento escolar vespertino" },
            new Especialidad { EspecialidadId = 6, Descripcion = "Acompañamiento actividad deportiva" },
            new Especialidad { EspecialidadId = 7, Descripcion = "Acompañamoento especial eventual" },
            new Especialidad { EspecialidadId = 8, Descripcion = "Cuidado de Personas con Parkinson" }

             );
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TEAyudo_Acompanantes;Trusted_Connection=True;TrustServerCertificate=True");
    }

}



