using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.DataAccess.Interfaces;

namespace UserManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService userService;
        
        public ValuesController( IUserService userService)
        {
            
            this.userService = userService;
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var res = await userService.GetAllUsers();
            return Ok(res);
        }  

        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var res = await userService.GetAllUsers(id);
            return Ok(res);
        }
    }
}
