using Xunit;
using Moq;
using MyStock.Application.DTOs;
using MyStock.Application.Services;
using MyStock.Domain.Entities;
using MyStock.Domain.Repositories;

namespace MyStock.Tests.Application
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_WithValidId_ReturnsProduct()
        {
            // Arrange
            var productId = 1;
            var product = new Product
            {
                Id = productId,
                Sku = "PROD001",
                Name = "Test Product",
                Price = 99.99m,
                Category = "Test"
            };

            _mockRepository.Setup(r => r.GetByIdAsync(productId))
                .ReturnsAsync(product);

            // Act
            var result = await _service.GetProductByIdAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal("PROD001", result.Sku);
            Assert.Equal("Test Product", result.Name);
        }

        [Fact]
        public async Task GetProductByIdAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Product?)null);

            // Act
            var result = await _service.GetProductByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProductAsync_WithValidData_CreatesProduct()
        {
            // Arrange
            var createDto = new CreateProductDto
            {
                Sku = "PROD002",
                Name = "New Product",
                Price = 149.99m,
                Category = "Electronics",
                Description = "Test description"
            };

            var productId = 2;
            _mockRepository.Setup(r => r.CreateAsync(It.IsAny<Product>()))
                .ReturnsAsync(productId);

            // Act
            var result = await _service.CreateProductAsync(createDto);

            // Assert
            Assert.Equal(productId, result);
            _mockRepository.Verify(r => r.CreateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_WithValidData_UpdatesProduct()
        {
            // Arrange
            var productId = 1;
            var existingProduct = new Product
            {
                Id = productId,
                Sku = "PROD001",
                Name = "Old Name",
                Price = 99.99m,
                Category = "Old Category"
            };

            var updateDto = new UpdateProductDto
            {
                Name = "New Name",
                Price = 199.99m
            };

            _mockRepository.Setup(r => r.GetByIdAsync(productId))
                .ReturnsAsync(existingProduct);

            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Product>()))
                .ReturnsAsync(true);

            // Act
            var result = await _service.UpdateProductAsync(productId, updateDto);

            // Assert
            Assert.True(result);
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Sku = "PROD001", Name = "Product 1", Category = "Test" },
                new Product { Id = 2, Sku = "PROD002", Name = "Product 2", Category = "Test" }
            };

            _mockRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(products);

            // Act
            var result = await _service.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
