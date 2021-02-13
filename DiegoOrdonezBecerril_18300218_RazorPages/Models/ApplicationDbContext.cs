using Microsoft.EntityFrameworkCore;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ProfesorToCurso> ProfesorToCurso { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfesorToCurso>().HasKey(k => new { k.ProfesorId, k.CursoId });

            modelBuilder.Entity<ProfesorToCurso>()
                .HasOne(x => x.Profesor)
                .WithMany(x => x.ProfesorToCursos)
                .HasForeignKey(x => x.ProfesorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProfesorToCurso>()
               .HasOne(x => x.Curso)
               .WithMany(x => x.ProfesorToCursos)
               .HasForeignKey(x => x.CursoId)
               .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
