namespace MyStock.Domain.Entities
{
    /// <summary>
    /// Entidad de movimiento de stock
    /// </summary>
    public class StockMovement
    {
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad del movimiento (positiva para entrada, negativa para salida)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Tipo de movimiento (Entrada, Salida, Ajuste)
        /// </summary>
        public string MovementType { get; set; } = string.Empty;

        /// <summary>
        /// Referencia o motivo del movimiento
        /// </summary>
        public string Reference { get; set; } = string.Empty;

        /// <summary>
        /// Fecha del movimiento
        /// </summary>
        public DateTime MovementDate { get; set; }

        /// <summary>
        /// Nota o comentario del movimiento
        /// </summary>
        public string? Notes { get; set; }

        public StockMovement()
        {
            MovementDate = DateTime.UtcNow;
        }
    }
}
