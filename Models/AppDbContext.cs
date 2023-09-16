using Microsoft.EntityFrameworkCore;

namespace DriveXpress.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
