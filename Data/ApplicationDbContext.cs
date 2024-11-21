using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestionEducativa.Models;

namespace GestionEducativa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>()
                .HasKey(carrera => carrera.Id);

            modelBuilder.Entity<Carrera>()
                .HasMany(c => c.Semestres)
                .WithOne(s => s.Carrera)
                .HasForeignKey(s => s.CarreraId);

            modelBuilder.Entity<Semestre>()
                .HasKey(semestre => semestre.Id);

            modelBuilder.Entity<Semestre>()
                .HasOne(semestre => semestre.Carrera)
                .WithMany(carrera => carrera.Semestres)
                .HasForeignKey(semestre => semestre.CarreraId);

            modelBuilder.Entity<Materia>()
                .HasKey(materia => materia.Id);

            modelBuilder.Entity<Materia>()
                .HasOne(materia => materia.Semestre)
                .WithMany(semestre => semestre.Materias)
                .HasForeignKey(materia => materia.SemestreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
