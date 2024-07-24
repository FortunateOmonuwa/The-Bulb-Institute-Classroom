using OrganizationMgtSys.DataAccess.Interfaces;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.DataAccess.Repositories
{
    public class StaffRepository : IBaseService<Staff>
    {
        public Task<Staff> CreateAsync(Staff entity)
        {
            throw new NotImplementedException();
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
