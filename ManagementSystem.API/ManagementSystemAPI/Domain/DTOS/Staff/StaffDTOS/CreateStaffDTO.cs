using ManagementSystemAPI.Domain.DTOS.AddressDto;
using ManagementSystemAPI.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Domain.DTOS.Staff.StaffDTOS
{
    public class CreateStaffDTO
    {



        public Guid CompanyID { get; set; }

        public CreateAddressDTO address { get; set; }

        public string FirstName { get; set; } 
        
        public string LastName { get; set; } 
        
        public string Email { get; set; } 


        public string PasswordHash { get; set; }

        ////public Role Role { get; set; }
        
        
        
        



    }
}
