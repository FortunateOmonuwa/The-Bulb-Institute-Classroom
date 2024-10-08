using ManagementSystemAPI.Domain.DTOS.Staff.StaffDTOS;
using ManagementSystemAPI.Domain.Models;

namespace ManagementSystemAPI.DataAccess.Interfaces
{
    public interface IStaffService
    {
        Task<Staff> CreateStaff (CreateStaffDTO staffDTO);
        Task<Staff>GetStaffById (Guid id);
        Task<GetStaffDTO> UpdateStaff(CreateStaffDTO staff);
        Task<List<Staff >> GetAllStafs();
        Task<string>DeleteStaff(Guid id);

    }
}
