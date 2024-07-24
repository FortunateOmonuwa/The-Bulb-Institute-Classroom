using Microsoft.EntityFrameworkCore;
using OrganizationMgtSys.DataAccess.DataContext;
using OrganizationMgtSys.DataAccess.Interfaces;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.DataAccess.Repositories
{
    public class CompanyRepository : IBaseService<Company>
    {
        private readonly ApplicationContext database;
        public CompanyRepository(ApplicationContext database) 
        {
            this.database = database;
        }
        public async Task<Company> CreateAsync(Company entity)
        {
            try
            {
                var company = await database.Companies.AnyAsync(x => x.Name == entity.Name);
                if (company)
                {
                    throw new Exception($"{entity.Name} already exists on our system");
                }
                if(entity.Address == null)
                {
                    throw new ArgumentNullException(nameof(entity.Address));
                }
                await database.Addresses.AddAsync(entity.Address);
                await database.Companies.AddAsync(entity);
                await database.SaveChangesAsync();
                return entity;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            try
            {
                var company = await database.Companies.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentNullException($"Company with Id {id} doesn't exist on our system");
                database.Companies.Remove(company);
                await database.SaveChangesAsync();
                return "Delete operation successful";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Company>> GetAll() => await database.Companies.ToListAsync();
       

        public async Task<Company> GetAsync(Guid id) => 
            await database.Companies
           .FirstOrDefaultAsync(x => x.Id == id)
           ?? throw new ArgumentNullException($"Company with Id {id} doesn't exist on our system");



        public Task<Company> UpdateAsync(Company entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
