using Store.DTO;

namespace Store.Interfaces.ProductInterfaces
{
    public interface IProduct
    {
        Task<ResponseDetail> AddProduct(ProductCreateDTO product);
    }
}
