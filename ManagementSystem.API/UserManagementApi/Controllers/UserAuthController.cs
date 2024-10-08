using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.DataAccess.Interface;
using UserManagementApi.DTOS;
using UserManagementApi.Service;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IEmailService _mail;
        private readonly IUserService _ctx;

        public UserAuthController(IEmailService mail,IUserService ctx)
        {
            _mail = mail;
            _ctx = ctx;
        }
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(MailRequest mail)
        {
            var res = await _mail.SendMail(mail);
            if (res.IsSuccessfull == true)
            {
                return Ok(res);

            }
            return BadRequest(res);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register user)
        {
            try
            {
                var res = await _ctx.RegisterUser(user);
                return Ok(res);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("VerifyAccount")]
        public async Task<IActionResult>VerifyAcct(string token)
        {
            var res = await _ctx.VerifyUser(token);
            if(res.IsSuccessfull == true)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login (Login login)
        {
             var res = await _ctx.Login(login);
            if(res.IsSuccessfull == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
