
using ManagementSystemAPI.DataAccess.DataContext;
using ManagementSystemAPI.DataAccess.Interfaces;
using ManagementSystemAPI.Domain.DTOS.AddressDto;
using ManagementSystemAPI.Domain.DTOS.Company;
using ManagementSystemAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace ManagementSystemAPI.DataAccess.Repositories
{
    public class CompanyRepository : ICompanyService
    { 
        private readonly ApplicationContext _ctx;
        public CompanyRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Company> CreateCompanyAsync(CreateCompanyDTO createDto)
        {

            try
            {
                var company = await _ctx.Companies.AnyAsync(x => x.Name == createDto.Name);
                if (company)
                {
                    throw new Exception($"Company {createDto.Name} already exist");
                }
                
                

                var addNewCompany = new Company()
                {
                    Name = createDto.Name,
                    Abbreviation = createDto.Abbreviation,
                    Address = new Address
                    {
                        StreetName = createDto.Address.StreetName,
                        State = createDto.Address.State,
                        PostalCode = createDto.Address.PostalCode,
                        Country = createDto.Address.Country
                    }

                };
                await _ctx.Companies.AddAsync(addNewCompany);
                await _ctx.SaveChangesAsync();
                return addNewCompany;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }



        }

        public async Task<string> DeleteCompanyAsync(Guid id)
        {
            try
            {
                var company = await _ctx.Companies.FirstOrDefaultAsync(x => x.ID == id);
                if (company == null)
                {
                    throw new Exception($"Company with Id {id} does not exist on our system");
                }
                _ctx.Companies.Remove(company);
                await _ctx.SaveChangesAsync();
                return "Company deleted Successfully";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Company>> GetAllCompanies() => await _ctx.Companies.Include(x => x.Address).ToListAsync();

        public async Task<Company> GetCompanyAsync(Guid id)
        {
            var company = await _ctx.Companies.FirstOrDefaultAsync(x => x.ID == id);
            if (company == null)
            {
                throw new Exception($"Company with Id {id} does not exist on our system");
            }
            return company;

        }

        public async Task<GetCompanyDTO> UpdateCompanyAsync(UpdateCompanyDTO company, Guid Id)
        {
            try
            {
                var companytoUpdate = await _ctx.Companies.FirstOrDefaultAsync(x => x.ID == Id);
                if (companytoUpdate == null)
                {
                    throw new Exception($"Company with Id {Id} does not exist on our system");
                }
                
                companytoUpdate.Name = company.Name ?? companytoUpdate.Name;
                companytoUpdate.Abbreviation = company.Abbreviation ?? companytoUpdate.Abbreviation;
                companytoUpdate.Address = new Address()
                {
                    StreetName = company.Address.StreetName ?? companytoUpdate.Address.StreetName,
                    Country = company.Address.Country,
                    PostalCode = company.Address.PostalCode,
                    State = company.Address.State,

                };

                 _ctx.Companies.Update(companytoUpdate);
                await _ctx.SaveChangesAsync();

                var GetUpdatedCompany = new GetCompanyDTO()
                {  
                  Id = companytoUpdate.ID,
                    Name = companytoUpdate.Name,
                    Address = new GetAddressDTO
                    {  
                        State = companytoUpdate.Address.State,
                        Country = companytoUpdate.Address.Country,
                        StreetName = companytoUpdate.Address.StreetName,
                        PostalCode = companytoUpdate.Address.PostalCode
                    },
                    Abbreviation = companytoUpdate.Abbreviation
                };

                return GetUpdatedCompany;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          

        }
    }
}
