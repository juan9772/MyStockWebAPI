using MyStock.Domain.Entities;
using MyStock.Domain.Repositories;

namespace MyStock.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de productos
    /// Nota: Usa una lista en memoria. En producción, usar una base de datos real
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        // Simulación de base de datos en memoria
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Sku = "PROD001",
                Name = "Producto Ejemplo 1",
                Description = "Descripción del producto 1",
                Price = 99.99m,
                Category = "Electrónica",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            },
            new Product
            {
                Id = 2,
                Sku = "PROD002",
                Name = "Producto Ejemplo 2",
                Description = "Descripción del producto 2",
                Price = 149.99m,
                Category = "Accesorios",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            }
        };

        private static int _nextId = 3;

        public Task<Product?> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<Product?> GetBySkuAsync(string sku)
        {
            var product = _products.FirstOrDefault(p => p.Sku == sku);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.Where(p => p.IsActive).AsEnumerable());
        }

        public Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return Task.FromResult(_products.Where(p => p.Category == category && p.IsActive).AsEnumerable());
        }

        public Task<int> CreateAsync(Product product)
        {
            product.Id = _nextId++;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            _products.Add(product);
            return Task.FromResult(product.Id);
        }

        public Task<bool> UpdateAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return Task.FromResult(false);

            existingProduct.Sku = product.Sku;
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.UpdatedAt = DateTime.UtcNow;
            existingProduct.IsActive = product.IsActive;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return Task.FromResult(false);

            product.IsActive = false;
            return Task.FromResult(true);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return Task.FromResult(_products.Any(p => p.Id == id && p.IsActive));
        }
    }
}
