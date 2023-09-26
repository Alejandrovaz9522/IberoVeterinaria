using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria; 

public class VeterinariaContext : DbContext
{
    public DbSet<Propietario> Propietario { get;set;}
    public DbSet<Mascota> Mascota {get;set;}
    public DbSet<Raza> Raza {get;set;}
    public DbSet<Tipo> Tipo {get;set;}

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Propietario>(propietario=> 
        {
            propietario.ToTable("propietario");
            propietario.HasKey(p=> p.PropietarioId);
            propietario.Property(p=> p.PropietarioId).IsRequired().ValueGeneratedOnAdd();
            propietario.Property(p=> p.Nombres).IsRequired().HasMaxLength(150);
            propietario.Property(p=> p.Apellidos).IsRequired(false).HasMaxLength(150);
            propietario.Property(p=> p.Documento).IsRequired().HasMaxLength(20);
            propietario.Property(p=> p.Genero).IsRequired().HasMaxLength(40);
        });

        modelBuilder.Entity<Mascota>(mascota=> 
        {
            mascota.ToTable("mascota");
            mascota.HasKey(p=> p.MascotaId);
            mascota.Property(p=> p.MascotaId).IsRequired().ValueGeneratedOnAdd();
            mascota.Property(p=> p.PropietarioId).IsRequired().HasMaxLength(20);
            mascota.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            mascota.Property(p=> p.TipoId).IsRequired().HasMaxLength(20);
            mascota.Property(p=> p.RazaId).IsRequired().HasMaxLength(20);
            mascota.Property(p=> p.PesoLb).IsRequired().HasMaxLength(20);
            mascota.Property(p=> p.Genero).IsRequired().HasMaxLength(40);
            mascota.HasOne(p=> p.Raza).WithMany(p=> p.Mascotas).HasForeignKey(p=> p.RazaId);
            mascota.HasOne(p=> p.Tipo).WithMany(p=> p.Mascotas).HasForeignKey(p=> p.TipoId);
            mascota.HasOne(p => p.Propietario).WithMany(p => p.Mascotas).HasForeignKey(p => p.PropietarioId);
        });

        modelBuilder.Entity<Raza>(raza=> 
        {
            raza.ToTable("raza");
            raza.HasKey(p=> p.RazaId);
            raza.Property(p=> p.RazaId).IsRequired().ValueGeneratedOnAdd();
            raza.Property(p=> p.DescripcionRaza).IsRequired().HasMaxLength(40);
        });

        modelBuilder.Entity<Tipo>(tipo=> 
        {
            tipo.ToTable("tipo");
            tipo.HasKey(p=> p.TipoId);
            tipo.Property(p=> p.TipoId).IsRequired().ValueGeneratedOnAdd();
            tipo.Property(p=> p.DescripcionTipo).IsRequired().HasMaxLength(40);
        });
    }
}