using System.ComponentModel.DataAnnotations;

namespace ManagementSystemAPI.Domain.DTOS.AddressDto
{
    public class CreateAddressDTO
    {
        public string StreetName { get; set; } 
        
        public string State { get; set; } 
        
        public string PostalCode { get; set; } = "";
       
        public string Country { get; set; } = "";
    }
}
