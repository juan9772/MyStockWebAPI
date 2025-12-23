using Xunit;
using Moq;
using MyStock.Application.DTOs;
using MyStock.Application.Services;
using MyStock.Domain.Entities;
using MyStock.Domain.Repositories;

namespace MyStock.Tests.Application
{
    public class StockServiceTests
    {
        private readonly Mock<IStockRepository> _mockRepository;
        private readonly StockService _service;

        public StockServiceTests()
        {
            _mockRepository = new Mock<IStockRepository>();
            _service = new StockService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetStockByProductIdAsync_WithValidProductId_ReturnsStock()
        {
            // Arrange
            var productId = 1;
            var stock = new Stock
            {
                Id = 1,
                ProductId = productId,
                AvailableQuantity = 50,
                ReservedQuantity = 10,
                MinimumQuantity = 20,
                MaximumQuantity = 200
            };

            _mockRepository.Setup(r => r.GetByProductIdAsync(productId))
                .ReturnsAsync(stock);

            // Act
            var result = await _service.GetStockByProductIdAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.ProductId);
            Assert.Equal(50, result.AvailableQuantity);
            Assert.Equal(60, result.TotalQuantity);
        }

        [Fact]
        public async Task GetLowStockAsync_ReturnsCommoditiesBelowMinimum()
        {
            // Arrange
            var lowStocks = new List<Stock>
            {
                new Stock { Id = 1, ProductId = 1, AvailableQuantity = 15, MinimumQuantity = 20 },
                new Stock { Id = 2, ProductId = 2, AvailableQuantity = 10, MinimumQuantity = 20 }
            };

            _mockRepository.Setup(r => r.GetLowStockAsync())
                .ReturnsAsync(lowStocks);

            // Act
            var result = await _service.GetLowStockAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddStockMovementAsync_Entrada_IncreasesAvailableQuantity()
        {
            // Arrange
            var stock = new Stock
            {
                Id = 1,
                ProductId = 1,
                AvailableQuantity = 50,
                ReservedQuantity = 10
            };

            var movementDto = new CreateStockMovementDto
            {
                ProductId = 1,
                Quantity = 20,
                MovementType = "Entrada",
                Reference = "PO-001"
            };

            _mockRepository.Setup(r => r.GetByProductIdAsync(1))
                .ReturnsAsync(stock);

            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Stock>()))
                .ReturnsAsync(true);

            // Act
            var result = await _service.AddStockMovementAsync(movementDto);

            // Assert
            Assert.True(result);
            Assert.Equal(70, stock.AvailableQuantity);
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Stock>()), Times.Once);
        }

        [Fact]
        public async Task AddStockMovementAsync_Salida_DecreasesAvailableQuantity()
        {
            // Arrange
            var stock = new Stock
            {
                Id = 1,
                ProductId = 1,
                AvailableQuantity = 50,
                ReservedQuantity = 10
            };

            var movementDto = new CreateStockMovementDto
            {
                ProductId = 1,
                Quantity = 20,
                MovementType = "Salida",
                Reference = "SO-001"
            };

            _mockRepository.Setup(r => r.GetByProductIdAsync(1))
                .ReturnsAsync(stock);

            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Stock>()))
                .ReturnsAsync(true);

            // Act
            var result = await _service.AddStockMovementAsync(movementDto);

            // Assert
            Assert.True(result);
            Assert.Equal(30, stock.AvailableQuantity);
        }

        [Fact]
        public async Task AddStockMovementAsync_Salida_WithInsufficientStock_ReturnsFalse()
        {
            // Arrange
            var stock = new Stock
            {
                Id = 1,
                ProductId = 1,
                AvailableQuantity = 10,
                ReservedQuantity = 5
            };

            var movementDto = new CreateStockMovementDto
            {
                ProductId = 1,
                Quantity = 20,
                MovementType = "Salida",
                Reference = "SO-001"
            };

            _mockRepository.Setup(r => r.GetByProductIdAsync(1))
                .ReturnsAsync(stock);

            // Act
            var result = await _service.AddStockMovementAsync(movementDto);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateStockAsync_WithValidData_UpdatesStock()
        {
            // Arrange
            var stockId = 1;
            var existingStock = new Stock
            {
                Id = stockId,
                ProductId = 1,
                AvailableQuantity = 50,
                MinimumQuantity = 20
            };

            var updateDto = new UpdateStockDto
            {
                AvailableQuantity = 75,
                ReservedQuantity = 5,
                MinimumQuantity = 30,
                MaximumQuantity = 200
            };

            _mockRepository.Setup(r => r.GetByIdAsync(stockId))
                .ReturnsAsync(existingStock);

            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Stock>()))
                .ReturnsAsync(true);

            // Act
            var result = await _service.UpdateStockAsync(stockId, updateDto);

            // Assert
            Assert.True(result);
            Assert.Equal(75, existingStock.AvailableQuantity);
            Assert.Equal(30, existingStock.MinimumQuantity);
        }
    }
}
