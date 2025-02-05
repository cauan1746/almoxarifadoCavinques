using AlmoxarifadoBackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasKey(c=>c.Codigo);
            modelBuilder.Entity<Categoria>().Property(c => c.Codigo).ValueGeneratedOnAdd();

            modelBuilder.Entity<Produtos>().HasKey(c => c.Id);
            modelBuilder.Entity<Produtos>().Property(c => c.Id).ValueGeneratedOnAdd();
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
    }
}
