namespace MyStock.Application.DTOs
{
    /// <summary>
    /// DTO para crear un movimiento de stock
    /// </summary>
    public class CreateStockMovementDto
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad del movimiento
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Tipo de movimiento (Entrada, Salida, Ajuste)
        /// </summary>
        public string MovementType { get; set; } = string.Empty;

        /// <summary>
        /// Referencia del movimiento
        /// </summary>
        public string Reference { get; set; } = string.Empty;

        /// <summary>
        /// Notas adicionales
        /// </summary>
        public string? Notes { get; set; }
    }
}
