using System.ComponentModel.DataAnnotations;

namespace UserManagement.API.Domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
