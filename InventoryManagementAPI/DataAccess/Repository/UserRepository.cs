using Azure;
using InventoryManagementAPI.DataAccess.DataContext;
using InventoryManagementAPI.DataAccess.Interface;
using InventoryManagementAPI.Domain;
using InventoryManagementAPI.DTOs.Product;
using InventoryManagementAPI.Helper;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _ctx;
        public UserRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ResponseModel<string>> AddProducts(ProductCreateDTO product)
        {
            var response = new ResponseModel<string>();
            try
            {
                var newProduct = new Product
                {
                   ProductName = product.ProductName,
                   Price = product.Price,
                   Description = product.Description,
                   Quantity = product.Quantity,
                   ExpiryDate = product.ExpiryDate,

                };
                await _ctx.AddAsync(newProduct);
                await _ctx.SaveChangesAsync();

                response = response.SuccessResult("Product added successfully");
                
            }
            
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel<string>> DeleteProduct(Guid Id)
        {
            var response = new ResponseModel<string>();

            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == Id);
                if(product == null)
                {
                    response = response.FailedResult("Error,product Id is invalid pls try again");
                }
                _ctx.Products.Remove(product!);
                await _ctx.SaveChangesAsync();

                response = response.SuccessResult("Product deleted successfully");

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _ctx.Products.ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetExpiredProducts()
        {
            try
            {
                var allexpiredProduct = await _ctx.Products.Where(x => x.ExpiryDate < DateTime.Now ).ToListAsync();
                if(allexpiredProduct.Count > 0)
                {
                    return allexpiredProduct;
                }
                else
                {
                    throw new Exception("All products are uptodate");
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductByID(Guid Id)
        {
            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x=> x.Id == Id);
                if(product == null)
                {
                    throw new Exception("Product not available");
                }
                return product;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<string>> GetQuantityProduct(Guid Id)
        {   
            var response = new ResponseModel<string>();

            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x=> x.Id == Id);
                if(product is null)
                {
                    response = response.FailedResult("Product Id is invalid, pls try again");
                }
                else
                {
                    response = response.SuccessResult($"We have {product.Quantity} {product.ProductName} left instock");
                }
                return response;
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateProduct(ProductUpdateDTO Updateproduct)
        {
            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == Updateproduct.Id);
                if (product is null)
                {
                    throw new Exception("Product ID is invalid, pls enter correct ID");
                }
                product.Id = product.Id;
                product.ProductName = product.ProductName ?? product.ProductName!;
                product.Quantity = Updateproduct.Quantity;
                product.Price = Updateproduct.Price;
                product.Description = Updateproduct.Description ?? product.Description;
                product.ExpiryDate = Updateproduct.ExpiryDate;

                _ctx.Products.Update(product);
               await  _ctx.SaveChangesAsync();
                return product;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
