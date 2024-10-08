using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string VerificationToken { get; set; }
        public bool Isverified { get; set; }
        public string TokenExpiration {  get; set; }
        public string VerifiedAt { get; set; }

        public List<UserRole> Roles { get; set; } = [];
    }
}
