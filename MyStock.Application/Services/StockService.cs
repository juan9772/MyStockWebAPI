using MyStock.Application.DTOs;
using MyStock.Domain.Entities;
using MyStock.Domain.Repositories;

namespace MyStock.Application.Services
{
    /// <summary>
    /// Servicio de aplicación para gestionar stock
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<StockDto?> GetStockByProductIdAsync(int productId)
        {
            var stock = await _stockRepository.GetByProductIdAsync(productId);
            return stock != null ? MapToDto(stock) : null;
        }

        public async Task<StockDto?> GetStockByIdAsync(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            return stock != null ? MapToDto(stock) : null;
        }

        public async Task<IEnumerable<StockDto>> GetAllStockAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return stocks.Select(s => MapToDto(s));
        }

        public async Task<IEnumerable<StockDto>> GetLowStockAsync()
        {
            var stocks = await _stockRepository.GetLowStockAsync();
            return stocks.Select(s => MapToDto(s));
        }

        public async Task<int> CreateStockAsync(int productId, UpdateStockDto updateStockDto)
        {
            var stock = new Stock
            {
                ProductId = productId,
                AvailableQuantity = updateStockDto.AvailableQuantity,
                ReservedQuantity = updateStockDto.ReservedQuantity,
                MinimumQuantity = updateStockDto.MinimumQuantity,
                MaximumQuantity = updateStockDto.MaximumQuantity,
                WarehouseLocation = updateStockDto.WarehouseLocation
            };

            return await _stockRepository.CreateAsync(stock);
        }

        public async Task<bool> UpdateStockAsync(int id, UpdateStockDto updateStockDto)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
                return false;

            stock.AvailableQuantity = updateStockDto.AvailableQuantity;
            stock.ReservedQuantity = updateStockDto.ReservedQuantity;
            stock.MinimumQuantity = updateStockDto.MinimumQuantity;
            stock.MaximumQuantity = updateStockDto.MaximumQuantity;
            stock.WarehouseLocation = updateStockDto.WarehouseLocation;
            stock.LastUpdated = DateTime.UtcNow;

            return await _stockRepository.UpdateAsync(stock);
        }

        public async Task<bool> AddStockMovementAsync(CreateStockMovementDto movementDto)
        {
            var stock = await _stockRepository.GetByProductIdAsync(movementDto.ProductId);
            if (stock == null)
                return false;

            if (movementDto.MovementType.ToLower() == "entrada")
            {
                stock.AvailableQuantity += movementDto.Quantity;
            }
            else if (movementDto.MovementType.ToLower() == "salida")
            {
                if (stock.AvailableQuantity < movementDto.Quantity)
                    return false;

                stock.AvailableQuantity -= movementDto.Quantity;
            }
            else if (movementDto.MovementType.ToLower() == "ajuste")
            {
                stock.AvailableQuantity += movementDto.Quantity;
            }

            stock.LastUpdated = DateTime.UtcNow;

            return await _stockRepository.UpdateAsync(stock);
        }

        public async Task<bool> DeleteStockAsync(int id)
        {
            return await _stockRepository.DeleteAsync(id);
        }

        private StockDto MapToDto(Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                AvailableQuantity = stock.AvailableQuantity,
                ReservedQuantity = stock.ReservedQuantity,
                TotalQuantity = stock.TotalQuantity,
                MinimumQuantity = stock.MinimumQuantity,
                MaximumQuantity = stock.MaximumQuantity,
                WarehouseLocation = stock.WarehouseLocation,
                LastUpdated = stock.LastUpdated,
                IsLowStock = stock.IsLowStock
            };
        }
    }
}
