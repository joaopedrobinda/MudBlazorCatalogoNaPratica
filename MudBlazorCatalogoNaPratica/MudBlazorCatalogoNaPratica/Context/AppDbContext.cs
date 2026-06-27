using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MudBlazorCatalogoNaPratica.Shared.Models;

namespace MudBlazorCatalogoNaPratica.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN", 
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    ConcurrencyStamp = "b8453489-0115-4fa8-b21a-c55dbfce1f93"
                });

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "a2df468e-28ff-451f-bfa9-e85df6ee47ab",
                    ConcurrencyStamp = "f09b5523-2877-45ea-971a-28e46950e32b"
                }
            );

        }

    }
}
