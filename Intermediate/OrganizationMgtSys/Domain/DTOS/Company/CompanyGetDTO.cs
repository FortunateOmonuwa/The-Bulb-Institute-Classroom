using OrganizationMgtSys.Domain.DTOS.AddressDTO;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.Domain.DTOS.Company
{
    public class CompanyGetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AddressGetDTO Address { get; set; }
        public string Abbreviation { get; set; }
    }
}
