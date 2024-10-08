using ManagementSystemAPI.DataAccess.DataContext;
using ManagementSystemAPI.DataAccess.Helper;
using ManagementSystemAPI.DataAccess.Interfaces;
using ManagementSystemAPI.Domain.DTOS.Staff.StaffDTOS;
using ManagementSystemAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemAPI.DataAccess.Repositories
{
    public class StaffRepository : IStaffService
    {
        private readonly ApplicationContext _ctx;
        public StaffRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Staff> CreateStaff(CreateStaffDTO staffDTO)
        { 

            try
            {
                
                var staff = await _ctx.Staffs.AnyAsync(x => x.Email == staffDTO.Email);
                if (staff)
                {
                    throw new Exception("Staff already exist");
                }

                
                
                var checkCompanyID = await _ctx.Companies.FirstOrDefaultAsync(c => c.ID == staffDTO.CompanyID);
                if (checkCompanyID == null)
                {
                    throw new Exception("Company ID does not exist");
                }





                var role = await _ctx.Roles.FirstOrDefaultAsync(x => x.Id == 1);

                var newStaff = new Staff()
                {
                    FirstName = staffDTO.FirstName,
                    LastName = staffDTO.LastName,
                    Email = staffDTO.Email,
                    CompanyID = staffDTO.CompanyID,
                    Address = new Address()
                    {
                        StreetName = staffDTO.address.StreetName,
                        PostalCode = staffDTO.address.PostalCode,
                        State = staffDTO.address.State,
                        Country = staffDTO.address.Country
                    },
                 

                    PasswordHash = validator.EncryptPassword(staffDTO.PasswordHash),
                    StaffUniqueNumber = validator.StaffUniqueNumber(checkCompanyID.Name),
                    
                    


                };

                await _ctx.Staffs.AddAsync(newStaff);
                var staffRole = new StaffRole()
                {
                    RoleId = role.Id,
                    StaffId = newStaff.ID,
                    Role = role,
                    Staff = newStaff
                };
                newStaff.Roles.Add(staffRole);

                await _ctx.AddAsync(newStaff);
                //await _ctx.Staffs.AddAsync(newStaff);
                var result = await _ctx.SaveChangesAsync();
                if(result < 1)
                {
                    throw new Exception("Unable to save to database ");
                }
                return newStaff;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteStaff(Guid id)
        {
            try
            {
                var staff = await _ctx.Staffs.FirstOrDefaultAsync(c => c.ID == id);
                if (staff == null)
                {
                    throw new Exception($"Staff with the id:{id} does not exist");
                }
                _ctx.Staffs.Remove(staff);
                await _ctx.SaveChangesAsync();
                return "Staff deleted succesfuly";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Staff>> GetAllStafs() => await _ctx.Staffs.Include(c => c.Address).ToListAsync();

        public async Task<Staff> GetStaffById(Guid id)
        {
            try
            {
                var staff = await _ctx.Staffs.Include(cs=>cs.Roles).Include(c=>c.Address).FirstOrDefaultAsync(c => c.ID == id);
                if (staff == null)
                {
                    throw new Exception($"Staff with id:{id} does not exist in the database");
                }
                return staff;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<GetStaffDTO> UpdateStaff(CreateStaffDTO staff)
        {
            throw new NotImplementedException();
        }
    }
}
