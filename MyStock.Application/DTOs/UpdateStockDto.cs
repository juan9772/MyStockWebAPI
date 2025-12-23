namespace MyStock.Application.DTOs
{
    /// <summary>
    /// DTO para crear o actualizar stock
    /// </summary>
    public class UpdateStockDto
    {
        /// <summary>
        /// Cantidad disponible
        /// </summary>
        public int AvailableQuantity { get; set; }

        /// <summary>
        /// Cantidad reservada
        /// </summary>
        public int ReservedQuantity { get; set; }

        /// <summary>
        /// Cantidad mínima
        /// </summary>
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Cantidad máxima
        /// </summary>
        public int MaximumQuantity { get; set; }

        /// <summary>
        /// Ubicación del almacén
        /// </summary>
        public string? WarehouseLocation { get; set; }
    }
}
