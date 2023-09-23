
using Microsoft.EntityFrameworkCore;
using TEAyudo;
using Microsoft.Extensions.Options;
using TEAyudo_Acompanantes;

namespace TEAyudo_Acompanantes;
public class TEAyudoContext :DbContext
{
    public DbSet<Acompanante> Acompanantes { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<ObraSocial> ObrasSociales { get; set; }
    public DbSet<AcompananteEspecialidad> AcompanantesEspecialidades { get; set; }
    public DbSet<AcompananteEspecialidad> AcompanantesObraSocial { get; set; }
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
            entity.Property(a => a.AcompananteId);
        });


        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.HasMany(a => a.Especialidades)
            .WithMany(e => e.Acompanantes)
            .UsingEntity<AcompananteEspecialidad>(
                j => j.HasOne(ae => ae.Especialidad).WithMany().OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(ae => ae.Acompanante).WithMany().OnDelete(DeleteBehavior.Restrict));
         });

        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.HasMany(a => a.DisponibilidadesSemanales)
            .WithOne(ds => ds.Acompanante)
            .HasForeignKey(ds => ds.AcompananteId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Acompanante>()
            .HasMany(a => a.Especialidades)
            .WithMany(e => e.Acompanantes)
            .UsingEntity<AcompananteEspecialidad>(
                j => j.HasOne(ae => ae.Especialidad).WithMany(),
                j => j.HasOne(ae => ae.Acompanante).WithMany());

        modelBuilder.Entity<Acompanante>()
            .HasMany(a => a.ObrasSociales)
            .WithMany(os => os.Acompanantes)
            .UsingEntity<AcompananteObraSocial>(
                j => j.HasOne(aos => aos.ObraSocial).WithMany(),
                j => j.HasOne(aos => aos.Acompanante).WithMany());

        modelBuilder.Entity<DisponibilidadSemanal>()
            .HasKey(d => d.DisponibilidadSemanalId);
    }


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TEAyudo_Acompanantes;Trusted_Connection=True;TrustServerCertificate=True");
    }

}



