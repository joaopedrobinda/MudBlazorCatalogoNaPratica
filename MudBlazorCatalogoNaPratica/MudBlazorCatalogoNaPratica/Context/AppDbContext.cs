using Microsoft.EntityFrameworkCore;
using MudBlazorCatalogoNaPratica.Shared.Models;

namespace MudBlazorCatalogoNaPratica.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = 1, Name = "Eletrônicos", Descricao = "Dispositivos de última geração, incluindo smartphones..." },
                new Categoria { CategoriaId = 2, Name = "Livros", Descricao = "Vasta coleção de obras literárias..." },
                new Categoria { CategoriaId = 3, Name = "Cozinha", Descricao = "Utensílios domésticos modernos..." }
            );
        }

    }
}
