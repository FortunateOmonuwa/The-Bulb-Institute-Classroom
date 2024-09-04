using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementAPI.Domain
{
    public class UserRole
    {
        [ForeignKey(nameof(Role))]
        public int RoleID { get; set; }
        public Role Role { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
