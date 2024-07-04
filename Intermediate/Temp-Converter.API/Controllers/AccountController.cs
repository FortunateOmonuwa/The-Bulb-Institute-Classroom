using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Temp_Converter.API.DTO;
using Temp_Converter.API.Interface;

namespace Temp_Converter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromBody]AccountCreationDTO new_acc)
        {
            try
            {
                var response = _account.CreateAccount(new_acc);
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
