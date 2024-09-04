namespace InventoryManagementAPI.DTOs.Product
{
    public class ProductResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired => ExpiryDate < DateTime.UtcNow;
    }
}
