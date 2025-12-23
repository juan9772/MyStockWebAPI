using MyStock.Application.DTOs;

namespace MyStock.Application.Services
{
    /// <summary>
    /// Interfaz del servicio de aplicación para productos
    /// </summary>
    public interface IProductService
    {
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductDto?> GetProductBySkuAsync(string sku);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
        Task<int> CreateProductAsync(CreateProductDto createProductDto);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
