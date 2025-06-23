using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.DTO;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productService;
        public ProductController(IProduct productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDTO product)
        {
            try
            {
                var req = await productService.AddProduct(product);
                if(req.IsSuccessful == false)
                {
                    return BadRequest(req);
                }
                return Ok(req);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
