using ManagementSystemAPI.DataAccess.Interfaces;
using ManagementSystemAPI.Domain.DTOS.LoginDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _log;
        public LoginController(ILogin log)
        {
            _log = log;
        }
        [HttpPost("Login")]

        public async Task<IActionResult>Login(Login login)
        {
            try
            {
                var res = await _log.Login(login);
                return Ok(res);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("LogoutUser")]
        public async Task<IActionResult>Logout(string mail)
        {
            try
            {
                var res = await _log.Logout(mail);
                return Ok(res);

            }catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
