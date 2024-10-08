using ManagementSystemAPI.DataAccess.Interfaces;
using ManagementSystemAPI.Domain.DTOS.Staff.StaffDTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _repo;
        public StaffController(IStaffService repo)
        {
            _repo = repo;
        }
        [HttpPost("CreateStaff")]
        public async Task<IActionResult>CreateStaff(CreateStaffDTO staffDTO)
        {
            try
            {
                var res = await _repo.CreateStaff(staffDTO);
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetStaffById")]
        public async Task<IActionResult>GetStaffByID(Guid id)
        {
            try
            {
                var res = await _repo.GetStaffById(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAllStaffs")]
        public async Task<IActionResult> GetAllStaffs()
        {
            try
            {
                var res = await _repo.GetAllStafs();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteStaff")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            try
            {
                var res = await _repo.DeleteStaff(id);
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
