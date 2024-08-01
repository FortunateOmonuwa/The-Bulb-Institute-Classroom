using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizationMgtSys.DataAccess.Interfaces;
using OrganizationMgtSys.Domain.DTOS.Company;
using OrganizationMgtSys.Domain.DTOS.StaffDTO;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IBaseService<Company> _companyService;
        private readonly IBaseService<Staff> _staffService;
        private IMapper mapper;
        public CompanyController(IBaseService<Company> companyService, IMapper mapper, IBaseService<Staff> staffService)
        {
            _companyService = companyService;
            this.mapper = mapper;
            _staffService = staffService;
        }

        [HttpPost("CreateNewCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDTO createModel)
        {
            try
            {
                var mapCompany = mapper.Map<Company>(createModel);
                var newCompany = await _companyService.CreateAsync(mapCompany);
                if(newCompany != null)
                {
                    var res = mapper.Map<CompanyGetDTO>(newCompany);
                    return Ok(res);
                }
                else
                {
                    return BadRequest(newCompany);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanyByID/{id}")]
        public async Task<IActionResult> GetCompanyByID(Guid id)
        {
            try
            {
                var  res = await _companyService.GetAsync(id);
                if(res != null)
                {
                    var company = mapper.Map<CompanyGetDTO>(res);
                    return Ok(company);

                }
                else
                {
                    return NotFound(res);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCompany")]
        public async Task<ActionResult> DeleteCompany(Guid id)
        {
            try
            {
                var res = await _companyService.DeleteAsync(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> FetchAllCompanies()
        {
            try
            {
                var res = await _companyService.GetAll();
                if(res == null)
                {
                    return NotFound();
                }
                else
                {
                    var companies = mapper.Map<List<CompanyGetDTO>>(res);
                    return Ok(companies);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateStaff([FromBody]StaffCreateDTO staff)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model state");
                }
                else
                {
                    var mapstaff = mapper.Map<Staff>(staff);
                    var newStaff = await _staffService.CreateAsync(mapstaff);
                    return Ok(newStaff);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

   
}
