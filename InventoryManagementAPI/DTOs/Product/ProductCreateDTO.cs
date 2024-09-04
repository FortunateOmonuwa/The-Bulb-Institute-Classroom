namespace InventoryManagementAPI.DTOs.Product
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; } 
    }
}
