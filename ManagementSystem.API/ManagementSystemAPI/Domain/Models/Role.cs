using System.ComponentModel.DataAnnotations;

namespace ManagementSystemAPI.Domain.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StaffRole> Staffs { get; set;}
    }
}
