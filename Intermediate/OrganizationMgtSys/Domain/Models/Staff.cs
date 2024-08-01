using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using OrganizationMgtSys.Domain.Models.Generic_Model;

namespace OrganizationMgtSys.Domain.Models
{
    public class Staff : GenericProps 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public DateTime HireDate { get; set; } = DateTime.Now;
        [Required, StringLength(10)]
        public string StaffUniqueNumber { get; set; }
        //[Required (ErrorMessage ="Role must be specified")]
        //public Role Role { get; set; } 
        public string Role { get; set; }
        [ForeignKey(nameof(Role))]
        public int RoleID { get; set; }
        public bool IsClockedIn { get; set; }
        public bool IsLoggedIn { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid? CompanyID { get; set; }

        [ForeignKey(nameof(Address))]
        public Guid? AddressID { get; set; }
        public Address? Address { get; set; }
        public List<Appraisal>? Appraisals { get; set; }
        public List<Query>? Queries { get; set; }
        public List<CheckIn>? CheckIns { get; set; }
        public List<Checkout>? CheckOuts { get; set; }

    }
}
