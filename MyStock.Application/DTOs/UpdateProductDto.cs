namespace MyStock.Application.DTOs
{
    /// <summary>
    /// DTO para actualizar un producto
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Descripción del producto
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Precio unitario
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Categoría del producto
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Estado activo/inactivo
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
