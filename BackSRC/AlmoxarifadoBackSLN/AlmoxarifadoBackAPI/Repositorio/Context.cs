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

            modelBuilder.Entity<Fornecedor>().HasKey(c => c.IdForn);
            modelBuilder.Entity<Fornecedor>().Property(c => c.IdForn).ValueGeneratedOnAdd();

            modelBuilder.Entity<Secretaria>().HasKey(c => c.IdSec);
            modelBuilder.Entity<Secretaria>().Property(c => c.IdSec).ValueGeneratedOnAdd();
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Secretaria> Secretaria { get; set; }
    }
}
