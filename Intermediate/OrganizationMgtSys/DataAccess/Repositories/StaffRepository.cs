using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using OrganizationMgtSys.DataAccess.DataContext;
using OrganizationMgtSys.DataAccess.Interfaces;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.DataAccess.Repositories
{
    public class StaffRepository : IBaseService<Staff>
    {
        private readonly ApplicationContext database;
        public StaffRepository(ApplicationContext database)
        {
            this.database = database;
        }
        public async Task<Staff> CreateAsync(Staff entity)
        {
            try
            {
               if(entity.FirstName == null || entity.LastName == null || entity.Email == null)
               {
                    throw new FormatException(" Entry cannot be null");
               }

               //checking for the company with the company id from the staff being created
               var company = await database.Companies
                    .Include(x=> x.Staffs)
                    .FirstOrDefaultAsync(x => x.Id == entity.CompanyID);

                var staff = company.Staffs.FirstOrDefault(s => s.Email == entity.Email);
                if (staff != null)
                {
                    throw new Exception($"Staff with Email: {entity.Email} already exists in {company.Name}");
                }
                var role = await database.Role.FirstOrDefaultAsync(x => x.Id.Equals(1));
                entity.Role = role.Name;
                entity.RoleID = role.Id;
                entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
                entity.HireDate = DateTime.Now.Date;
                company.Staffs.Add(entity);
                //await database.Staff.AddAsync(entity);
                await database.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<string> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Staff>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Staff> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> UpdateAsync(Staff entity, Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
