using ManagementSystemAPI.DataAccess.Interfaces;
using ManagementSystemAPI.Domain.DTOS.Company;
using ManagementSystemAPI.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyctx;
        public CompanyController(ICompanyService companyctx)
        {
            _companyctx = companyctx;
        }
        [HttpPost("CreateNewCompany")]
        public async Task<IActionResult> CreateCompany([FromBody]CreateCompanyDTO createDTO)
        {
            try
            {
                var res = await _companyctx.CreateCompanyAsync(createDTO);
                return Ok(res);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetCompanybyId/{id}")]
        public async Task<IActionResult> GetCompanybyId(Guid id)
        {
            try
            {
                var res = await _companyctx.GetCompanyAsync(id);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompaines()
        {
            try
            {
                var res = await _companyctx.GetAllCompanies();
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDTO companyToupdate , Guid id)
        {
            try
            {
                var res = await _companyctx.UpdateCompanyAsync(companyToupdate, id);    
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            try
            {
                var res = await _companyctx.DeleteCompanyAsync(id);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
