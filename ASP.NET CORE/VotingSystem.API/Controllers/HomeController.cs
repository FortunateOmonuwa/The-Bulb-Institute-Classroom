using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
      

        [HttpPost("Login")]
        public IActionResult Login(string name)
        {
            if(name.Length < 5)
            {
                return BadRequest("Name too short");
            }
            else if(name != "Fortunate")
            {
                return Unauthorized("You don't have access to this facility");
            }
            else if(name == "Akanbi")
            {
                return NotFound($"{name} does not exist");
            }
            else if(name == "Fortunate")
            {
            return Ok($"Mr {name}... You have successfully logged in");

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
