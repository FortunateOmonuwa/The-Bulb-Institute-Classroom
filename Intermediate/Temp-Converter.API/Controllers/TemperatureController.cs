using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Temp_Converter.API.Models;

namespace Temp_Converter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperature _temperature;
        public TemperatureController(ITemperature temperature) 
        { 
            _temperature = temperature;
        }


        [HttpGet("ConvertToFahrenheit")]
        public IActionResult ConvertToFahrenheit(int temp)
        {
            try
            {
                var result = _temperature.ConvertToFahrenheit(temp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ConvertToCelsius")]
        public IActionResult ConvertToCelsius([FromBody]int temp)
        {
            try
            {
                var result = _temperature.ConvertToCelsius(temp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
