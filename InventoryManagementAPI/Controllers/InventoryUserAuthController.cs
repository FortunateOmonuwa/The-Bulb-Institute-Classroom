using InventoryManagementAPI.DataAccess.Interface;
using InventoryManagementAPI.DTOs.Register_login;
using InventoryManagementAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryUserAuthController : ControllerBase
    {
        private readonly IRegister_Login _ctx;
        public InventoryUserAuthController(IRegister_Login ctx )
        {
            _ctx = ctx;
          
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register(Register register)
        {
            try
            {
            var res = await _ctx.RegisterAdmin(register);
            return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var res = await _ctx.Login(login);
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("VerifyUser")]
        public async Task<IActionResult> Verify(string token)
        {
            try
            {
                var res = await _ctx.VerifyUser(token);
                return Ok(res);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RegenerateToken")]
        public async Task<IActionResult> RegenerateToken(string email)
        {
            try
            {
                var res = await _ctx.RegenerateToken(email);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
