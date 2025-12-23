using MyStock.Application.DTOs;
using MyStock.Domain.Entities;
using MyStock.Domain.Repositories;

namespace MyStock.Application.Services
{
    /// <summary>
    /// Servicio de aplicación para gestionar productos
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<ProductDto?> GetProductBySkuAsync(string sku)
        {
            var product = await _productRepository.GetBySkuAsync(sku);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => MapToDto(p));
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepository.GetByCategoryAsync(category);
            return products.Select(p => MapToDto(p));
        }

        public async Task<int> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Sku = createProductDto.Sku,
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Category = createProductDto.Category
            };

            return await _productRepository.CreateAsync(product);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;

            if (!string.IsNullOrEmpty(updateProductDto.Name))
                product.Name = updateProductDto.Name;

            if (!string.IsNullOrEmpty(updateProductDto.Description))
                product.Description = updateProductDto.Description;

            if (updateProductDto.Price.HasValue && updateProductDto.Price.Value > 0)
                product.Price = updateProductDto.Price.Value;

            if (!string.IsNullOrEmpty(updateProductDto.Category))
                product.Category = updateProductDto.Category;

            if (updateProductDto.IsActive.HasValue)
                product.IsActive = updateProductDto.IsActive.Value;

            product.UpdatedAt = DateTime.UtcNow;

            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Sku = product.Sku,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                IsActive = product.IsActive
            };
        }
    }
}
