using ManagementSystemAPI.Domain.DTOS.Company;
using ManagementSystemAPI.Domain.Models;

namespace ManagementSystemAPI.DataAccess.Interfaces
{
    public interface ICompanyService
    {
        Task <Company> CreateCompanyAsync (CreateCompanyDTO createDto);
        Task<List<Company>> GetAllCompanies();

        Task<GetCompanyDTO> UpdateCompanyAsync (UpdateCompanyDTO company,Guid Id);
        Task<Company> GetCompanyAsync(Guid id);
        Task<string> DeleteCompanyAsync(Guid id);

    }
}
