using OrganizationMgtSys.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrganizationMgtSys.Domain.DTOS.StaffDTO
{
    public class StaffGetDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string StaffUniqueNumber { get; set; } 
        public string Role { get; set; }
        public int RoleID { get; set; }
        public bool IsClockedIn { get; set; }
        public bool IsLoggedIn { get; set; }
        public Guid? CompanyID { get; set; }
        public Address? Address { get; set; }
    }
}
