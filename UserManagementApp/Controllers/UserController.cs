using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApp.DataAccess.Interface;
using UserManagementApp.Domain.DTO;

namespace UserManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _repo;
        public UserController(IUserService repo)
        {
            _repo = repo;
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO userdto)
        {
            try
            {
                var res = await _repo.RegisterUser(userdto);
                return Ok(res);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO logindto)
        {
            try
            {
                var res = await _repo.LoginUser(logindto);
                return Ok(res); 
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
