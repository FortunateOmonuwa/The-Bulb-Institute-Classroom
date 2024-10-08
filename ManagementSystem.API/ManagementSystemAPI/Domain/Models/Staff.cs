
using ManagementSystemAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Domain.Models
{
    public class Staff
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required]

        public string? PasswordHash { get; set; }
        [Required]
        public string HireDate { get; set; } = DateTime.Now.ToString("G");
        [Required,StringLength(10)]
        public string StaffUniqueNumber { get; set; } = "";
        
        public List<StaffRole> Roles { get; set; } = [];

        public bool IsClockedIn { get; set; }
        public bool IsLoggedIn { get; set; }
        [ForeignKey(nameof(Company))]
        public Guid CompanyID {  get; set; }
        [ForeignKey(nameof(Address))]
        public Guid? AddressID {  get; set; }   
        public Address? Address { get; set; }
        
        public List<Appraisal>? Appraisals { get; set; }

        public List<Query>? Queries { get; set; }
        
        public List<Clockin>? ClockIns { get; set; }
        public List<ClockOut>? ClockOuts { get; set; }



    }


}
