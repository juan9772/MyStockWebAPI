namespace MyStock.Domain.Entities
{
    /// <summary>
    /// Entidad que representa el stock actual de un producto
    /// </summary>
    public class Stock
    {
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad disponible en stock
        /// </summary>
        public int AvailableQuantity { get; set; }

        /// <summary>
        /// Cantidad reservada
        /// </summary>
        public int ReservedQuantity { get; set; }

        /// <summary>
        /// Cantidad mínima recomendada
        /// </summary>
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Cantidad máxima de almacenamiento
        /// </summary>
        public int MaximumQuantity { get; set; }

        /// <summary>
        /// Ubicación o depósito donde se almacena
        /// </summary>
        public string? WarehouseLocation { get; set; }

        /// <summary>
        /// Fecha de última actualización del stock
        /// </summary>
        public DateTime LastUpdated { get; set; }

        public Stock()
        {
            LastUpdated = DateTime.UtcNow;
        }

        /// <summary>
        /// Obtiene la cantidad total de stock (disponible + reservado)
        /// </summary>
        public int TotalQuantity => AvailableQuantity + ReservedQuantity;

        /// <summary>
        /// Indica si el stock está bajo el mínimo
        /// </summary>
        public bool IsLowStock => AvailableQuantity <= MinimumQuantity;
    }
}
