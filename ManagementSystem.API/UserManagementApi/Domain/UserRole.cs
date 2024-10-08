using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Domain
{
    public class UserRole
    {
        [ForeignKey(nameof(Role))]
        public int RoleID { get; set; }
        public Role Role { get; set; }
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
