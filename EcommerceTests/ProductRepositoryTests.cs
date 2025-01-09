using EcommerceModels;
using EcommercePersistence;
using EcommerceRepositories;
using Microsoft.EntityFrameworkCore;
namespace EcommerceTests
{
    public class ProductRepositoryTests
    {
        private EcommerceDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<EcommerceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique database name
            .Options;

            var context = new EcommerceDbContext(options);

            // Seed data
            context.Products.AddRange(
                new Product { Id = 1, Name = "Laptop", Description = "High-end laptop", Price = 1500.00m, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Description = "Latest smartphone", Price = 999.99m, Stock = 50 }
            );
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ProductRepository(context);

            // Act
            var products = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(products);
            Assert.Equal(2, products.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectProduct()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ProductRepository(context);

            // Act
            var product = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(product);
            Assert.Equal("Laptop", product?.Name);
        }

        [Fact]
        public async Task AddAsync_ShouldAddProduct()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ProductRepository(context);
            var newProduct = new Product { Id = 3, Name = "Tablet", Description = "New tablet", Price = 500.00m, Stock = 20 };

            // Act
            await repository.AddAsync(newProduct);
            var product = await repository.GetByIdAsync(3);

            // Assert
            Assert.NotNull(product);
            Assert.Equal("Tablet", product?.Name);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveProduct()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ProductRepository(context);
            var product = await repository.GetByIdAsync(1);

            // Act
            await repository.DeleteAsync(product!);
            var products = await repository.GetAllAsync();

            // Assert
            Assert.Equal(1, products.Count());
        }
    }
}