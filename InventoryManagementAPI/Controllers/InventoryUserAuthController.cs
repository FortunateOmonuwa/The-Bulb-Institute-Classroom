using InventoryManagementAPI.DataAccess.Interface;
using InventoryManagementAPI.DTOs.Register_login;
using InventoryManagementAPI.Service;
using Microsoft.AspNetCore.Authorization;
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
       
        [HttpPost("RegisterAdmin")]

        public async Task<IActionResult> RegisterAdmin(Register register)
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
      
          [HttpPost("RegisterStaff")]

        public async Task<IActionResult> RegisteraStaff(Register register)
        {
            try
            {
            var res = await _ctx.RegisterStaff(register);
            return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("RegisterCustomer")]

        public async Task<IActionResult> RegisterCustumer(Register register)
        {
            try
            {
                var res = await _ctx.RegisterCustumer(register);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetallUsers()
        {
            var res = await _ctx.GetAllUsers();
            return Ok(res);
        }
        [Authorize(Roles = "Admin,Staff")]
        [HttpGet("GetUserId")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var res = await _ctx.GetUserByID(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _ctx.DeleteUser(id);
            return Ok(res);
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
