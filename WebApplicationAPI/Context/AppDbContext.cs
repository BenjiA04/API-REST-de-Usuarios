using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioAutenticado> UsuarioAutenticados { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoría> Categorías { get; set; }

        // Modificar el tipo de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Nombre)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Usuario>()
                .Property(p => p.Correo)
                .HasColumnType("varchar(30)");
        }
    }
}
