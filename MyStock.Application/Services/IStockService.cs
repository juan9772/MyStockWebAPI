using MyStock.Application.DTOs;

namespace MyStock.Application.Services
{
    /// <summary>
    /// Interfaz del servicio de aplicación para stock
    /// </summary>
    public interface IStockService
    {
        Task<StockDto?> GetStockByProductIdAsync(int productId);
        Task<StockDto?> GetStockByIdAsync(int id);
        Task<IEnumerable<StockDto>> GetAllStockAsync();
        Task<IEnumerable<StockDto>> GetLowStockAsync();
        Task<int> CreateStockAsync(int productId, UpdateStockDto updateStockDto);
        Task<bool> UpdateStockAsync(int id, UpdateStockDto updateStockDto);
        Task<bool> AddStockMovementAsync(CreateStockMovementDto movementDto);
        Task<bool> DeleteStockAsync(int id);
    }
}
