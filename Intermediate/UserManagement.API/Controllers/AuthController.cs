using Microsoft.AspNetCore.Mvc;
using UserManagement.API.DataAccess.Interfaces;
using UserManagement.API.DTOs;
using UserManagement.API.Service;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserService userService;  
        private readonly IMailService mailService;

        public AuthController(IMailService mailService, IUserService userService)
        {
            this.mailService = mailService;  
            this.userService = userService;
        }
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(MailRequest mail)
        {
            var req = await mailService.SendMail(mail);
            if(req.IsSuccessful == true)
            {
                return Ok(req);
            }
            else
            {
                return BadRequest(req);
            }
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            try
            {
                var req = await userService.Register(register);
                if(req.ResultCode == 200)
                {
                    return Ok(req);
                }
                else
                {
                    return BadRequest(req);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("VerifyAccount")]
        public async Task<IActionResult> VerifyAccount(string token)
        {
            var req = await userService.VerifyAccount(token);
            if(req.IsSuccessful == true)
            {
                return Ok(req);
            }
            else
            {
                return BadRequest(req);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            try
            {
                var req = await userService.Login(login);
                return Ok(req);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
