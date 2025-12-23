namespace MyStock.Application.DTOs
{
    /// <summary>
    /// DTO para respuesta de stock
    /// </summary>
    public class StockDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int MinimumQuantity { get; set; }
        public int MaximumQuantity { get; set; }
        public string? WarehouseLocation { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsLowStock { get; set; }
    }
}
