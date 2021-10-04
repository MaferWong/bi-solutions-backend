using Microsoft.EntityFrameworkCore;
using BISolutions.Models;

namespace BISolutions.DataContext
{
    public class BISolutionsDataContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Reporte_Rol> Reportes_Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WONG;DataBase=BISolutions;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RolMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new ReporteMapping());
            modelBuilder.ApplyConfiguration(new Reporte_RolMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
