using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string Name { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string PasswordHash { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string UserCode { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string UserType { get; set; } = "";
    }
}
