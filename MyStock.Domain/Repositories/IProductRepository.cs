using MyStock.Domain.Entities;

namespace MyStock.Domain.Repositories
{
    /// <summary>
    /// Interfaz del repositorio de productos
    /// </summary>
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetBySkuAsync(string sku);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);
        Task<int> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
