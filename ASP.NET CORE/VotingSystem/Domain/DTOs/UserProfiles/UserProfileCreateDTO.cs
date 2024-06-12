using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain.DTOs.UserProfiles
{
    public class UserProfileCreateDTO
    {
        public string Email { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string LastName { get; set; } = ""; 
        [Required, DataType(DataType.Text)]
        public string FirstName { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string Password { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string UserCode { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string UserType { get; set; } = "";
    }
}
