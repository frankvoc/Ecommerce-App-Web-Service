using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceBusinessLogic;
using EcommerceModels;
using EcommerceRepositories;
using Moq;
namespace EcommerceTests
{
    public class ProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IRepository<Product>>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Description = "Gaming laptop", Price = 1500.00m, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Description = "Smartphone", Price = 999.99m, Stock = 50 }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Name == "Laptop");
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnCorrectProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Laptop", Description = "Gaming laptop", Price = 1500.00m, Stock = 10 };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Laptop", result?.Name);
        }

        [Fact]
        public async Task AddProductAsync_ShouldCallRepositoryAddMethod()
        {
            // Arrange
            var productDto = new ProductDTO { Name = "Tablet", Description = "New tablet", Price = 500.00m, Stock = 20 };

            // Act
            await _productService.AddProductAsync(productDto);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateExistingProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Old Laptop", Description = "Old gaming laptop", Price = 1000.00m, Stock = 5 };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            var updatedDto = new ProductDTO { Name = "New Laptop", Description = "Updated gaming laptop", Price = 1500.00m, Stock = 10 };

            // Act
            await _productService.UpdateProductAsync(1, updatedDto);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(It.Is<Product>(p =>
                p.Name == "New Laptop" &&
                p.Description == "Updated gaming laptop" &&
                p.Price == 1500.00m &&
                p.Stock == 10)), Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldRemoveProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Laptop", Description = "Gaming laptop", Price = 1500.00m, Stock = 10 };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            await _productService.DeleteProductAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}
