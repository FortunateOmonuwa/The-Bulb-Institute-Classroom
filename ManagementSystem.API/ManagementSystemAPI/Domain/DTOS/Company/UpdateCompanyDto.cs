using ManagementSystemAPI.Domain.DTOS.AddressDto;

namespace ManagementSystemAPI.Domain.DTOS.Company
{
    public class UpdateCompanyDTO
    {
        public string Name { get; set; } = "";

        public CreateAddressDTO? Address { get; set; }
        public string Abbreviation { get; set; } = "";
    }
}
