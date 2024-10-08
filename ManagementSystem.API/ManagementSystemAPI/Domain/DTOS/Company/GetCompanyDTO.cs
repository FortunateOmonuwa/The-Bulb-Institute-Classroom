using ManagementSystemAPI.Domain.DTOS.AddressDto;

namespace ManagementSystemAPI.Domain.DTOS.Company
{
    public class GetCompanyDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public GetAddressDTO Address { get; set; }

        public string Abbreviation { get; set; } = "";
    }
}
