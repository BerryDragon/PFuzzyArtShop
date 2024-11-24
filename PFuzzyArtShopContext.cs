using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PFuzzyArtShop.Models;
using PFuzzyArtShop.Models.IdentityModels;

namespace PFuzzyArtShop.Models
{
    public class FuzzyContext : IdentityDbContext<FuzzyShopUser>
    {
        public FuzzyContext(DbContextOptions<FuzzyContext> options) : base(options)
        {
        }

        public DbSet<Merch> Merch { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Merch>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Merch>().HasData(
                new Merch { Id = 1, Name = "Jacket", Price = 50.00m, Size = "L" },
                new Merch { Id = 2, Name = "KeyChain", Price = 5.00m, Size = "" }
            );
        }
    }
}
// Remember to add new DB JSON updates from EFOn 9.0
