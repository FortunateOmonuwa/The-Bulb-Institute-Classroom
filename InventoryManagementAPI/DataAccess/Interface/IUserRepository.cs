using InventoryManagementAPI.Domain;
using InventoryManagementAPI.DTOs.Product;

using InventoryManagementAPI.Helper;

namespace InventoryManagementAPI.DataAccess.Interface
{
    public interface IUserRepository
    {

        // Admin only Functionality
        Task<ResponseModel<string>> AddProducts(ProductCreateDTO product);
        Task<Product> UpdateProduct(ProductUpdateDTO product);
        Task<ResponseModel<string>> DeleteProduct(Guid Id);

        Task<List<Product>> GetAllProducts();

        // Staff and admin functionality
        Task<Product> GetProductByID(Guid Id);
        Task<List<Product>> GetExpiredProducts();
        Task<ResponseModel<string>> GetQuantityProduct(Guid Id);



    }
}
