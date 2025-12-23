namespace MyStock.Application.DTOs
{
    /// <summary>
    /// DTO para crear un producto
    /// </summary>
    public class CreateProductDto
    {
        /// <summary>
        /// Código único del producto (SKU)
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
        /// Precio unitario
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Categoría del producto
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
