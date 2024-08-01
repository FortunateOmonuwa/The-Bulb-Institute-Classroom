using OrganizationMgtSys.Domain.DTOS.AddressDTO;

namespace OrganizationMgtSys.Domain.DTOS.StaffDTO
{
    public class StaffCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public string Email { get; set; }
        public string Password { get; set; }
        public string StaffUniqueNumber { get; set; }    
        public Guid? CompanyID { get; set; }
        public AddressCreateDTO Address { get; set; }
    }
}
