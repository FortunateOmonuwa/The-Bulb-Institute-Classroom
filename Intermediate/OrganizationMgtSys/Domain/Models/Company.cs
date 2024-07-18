using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.Models
{
    public class Company : GenericProps
    {
        public TimeSpan StandardCheckinTime {  get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan StandardCheckOutTime {  get; set; } = new TimeSpan(17, 0, 0);

        public string Name { get; set; }

        [ForeignKey(nameof(Address))]
        public Guid AddressID { get; set; }
        public Address? Address { get; set; }
        public string Abbreviation { get; set; }
        public List<Staff>? Staffs { get; set; }
        //public List<Role>? Roles { get; set; }
       
    }
}