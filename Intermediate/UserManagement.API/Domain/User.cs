using System.ComponentModel.DataAnnotations;

namespace UserManagement.API.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
       // public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string VerificationToken { get; set; }
        public bool IsVerified { get; set; }    
        public DateTime VerifiedAt { get; set; }
        public List<UserRole>? UserRoles { get; set; }

    }
}
