using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Domain.Models
{
    public class StaffRole
    {
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey(nameof(Staff))]
        public Guid StaffId { get; set; }

        public Staff Staff { get; set; }
    }
}
