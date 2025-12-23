using MyStock.Domain.Entities;
using MyStock.Domain.Repositories;

namespace MyStock.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de stock
    /// Nota: Usa una lista en memoria. En producción, usar una base de datos real
    /// </summary>
    public class StockRepository : IStockRepository
    {
        // Simulación de base de datos en memoria
        private static List<Stock> _stocks = new List<Stock>
        {
            new Stock
            {
                Id = 1,
                ProductId = 1,
                AvailableQuantity = 50,
                ReservedQuantity = 10,
                MinimumQuantity = 20,
                MaximumQuantity = 200,
                WarehouseLocation = "A1",
                LastUpdated = DateTime.UtcNow
            },
            new Stock
            {
                Id = 2,
                ProductId = 2,
                AvailableQuantity = 15,
                ReservedQuantity = 5,
                MinimumQuantity = 20,
                MaximumQuantity = 150,
                WarehouseLocation = "B2",
                LastUpdated = DateTime.UtcNow
            }
        };

        private static int _nextId = 3;

        public Task<Stock?> GetByProductIdAsync(int productId)
        {
            var stock = _stocks.FirstOrDefault(s => s.ProductId == productId);
            return Task.FromResult(stock);
        }

        public Task<Stock?> GetByIdAsync(int id)
        {
            var stock = _stocks.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(stock);
        }

        public Task<IEnumerable<Stock>> GetAllAsync()
        {
            return Task.FromResult(_stocks.AsEnumerable());
        }

        public Task<IEnumerable<Stock>> GetLowStockAsync()
        {
            return Task.FromResult(_stocks.Where(s => s.IsLowStock).AsEnumerable());
        }

        public Task<int> CreateAsync(Stock stock)
        {
            stock.Id = _nextId++;
            stock.LastUpdated = DateTime.UtcNow;
            _stocks.Add(stock);
            return Task.FromResult(stock.Id);
        }

        public Task<bool> UpdateAsync(Stock stock)
        {
            var existingStock = _stocks.FirstOrDefault(s => s.Id == stock.Id);
            if (existingStock == null)
                return Task.FromResult(false);

            existingStock.ProductId = stock.ProductId;
            existingStock.AvailableQuantity = stock.AvailableQuantity;
            existingStock.ReservedQuantity = stock.ReservedQuantity;
            existingStock.MinimumQuantity = stock.MinimumQuantity;
            existingStock.MaximumQuantity = stock.MaximumQuantity;
            existingStock.WarehouseLocation = stock.WarehouseLocation;
            existingStock.LastUpdated = DateTime.UtcNow;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var stock = _stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
                return Task.FromResult(false);

            _stocks.Remove(stock);
            return Task.FromResult(true);
        }
    }
}
