using InventoryManagementAPI.DataAccess.Interface;
using InventoryManagementAPI.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public ProductController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("AddNewProduct")]
        public async Task <IActionResult> AddProduct(ProductCreateDTO _dto)
        {
            try
            {
                var response = await _repo.AddProducts(_dto);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateProduct")]
        public async Task <IActionResult> UpdateProduct(ProductUpdateDTO _dto)
        {
            try
            {
                var response = await _repo.UpdateProduct(_dto);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        
        [HttpGet("GetAllProduct")]
        public async Task <IActionResult> GetAllProduct()
        {
            try
            {
                var response = await _repo.GetAllProducts();
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetAllExpiredProduct")]
        public async Task <IActionResult> GetAllExpiredProduct()
        {
            try
            {
                var response = await _repo.GetExpiredProducts();
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpGet("GetProductByID")]
        public async Task <IActionResult> GetProductById(Guid id)
        {
            try
            {
                var response = await _repo.GetProductByID(id);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
          [HttpGet("GetQuantityByID")]
        public async Task <IActionResult> GetQuantityByID(Guid id)
        {
            try
            {
                var response = await _repo.GetQuantityProduct(id);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpDelete("DeleteProductByID")]
        public async Task <IActionResult> DeleteProductById(Guid id)
        {
            try
            {
                var response = await _repo.DeleteProduct(id);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
