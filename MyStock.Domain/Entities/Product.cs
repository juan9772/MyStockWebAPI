namespace MyStock.Domain.Entities
{
    /// <summary>
    /// Entidad de producto del dominio
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        /// <summary>
        /// Código único del producto
        /// </summary>
        public string Sku { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Precio unitario del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Categoría del producto
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha de última actualización
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Indica si el producto está activo
        /// </summary>
        public bool IsActive { get; set; }

        public Product()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
        }
    }
}
