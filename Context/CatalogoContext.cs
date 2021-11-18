using CatalogoProdutos.Dtos;
using CatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Context
{
    public class CatalogoContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=****;Password=****;Host=localhost;Port=5432;Database=CategoriaProdutos;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(p => p.CodigoCategoria);
        }
    }
}
