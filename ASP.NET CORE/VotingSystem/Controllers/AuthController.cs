using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.DataAccess.Interfaces;
using VotingSystem.Domain.DTOs.LoginDTO;

namespace VotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var res = await authService.Login(login);   
                if(res._statusCode is 400)
                {
                    return BadRequest(res);
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
