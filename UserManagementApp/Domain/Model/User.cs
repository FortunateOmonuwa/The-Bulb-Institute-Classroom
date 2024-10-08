using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.Domain.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string UserName { get; set; } = "";
    }
}
