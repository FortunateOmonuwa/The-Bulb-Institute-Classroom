using System.ComponentModel.DataAnnotations;

namespace InventoryManagementAPI.Domain
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string VerificationToken { get; set; }
        public bool Isverified { get; set; }
        public string TokenExpiration { get; set; }
        public string VerifiedAt { get; set; }

        public List<UserRole> Roles { get; set; } = [];
    }
}
