using MyStock.Domain.Entities;

namespace MyStock.Domain.Repositories
{
    /// <summary>
    /// Interfaz del repositorio de stock
    /// </summary>
    public interface IStockRepository
    {
        Task<Stock?> GetByProductIdAsync(int productId);
        Task<Stock?> GetByIdAsync(int id);
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<IEnumerable<Stock>> GetLowStockAsync();
        Task<int> CreateAsync(Stock stock);
        Task<bool> UpdateAsync(Stock stock);
        Task<bool> DeleteAsync(int id);
    }
}
