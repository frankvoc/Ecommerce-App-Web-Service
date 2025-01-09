using EcommerceModels;
using Microsoft.EntityFrameworkCore;
namespace EcommercePersistence
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Test data
            //DB should HOPPEFULLY already be pre populated but here is some dummy data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "gaming laptop", Price = 1500.00m, Stock = 10 },
                new Product { Id = 2, Name = "Smartphone", Description = "smartphone", Price = 999.99m, Stock = 50 }
            );
        }
    }
}
