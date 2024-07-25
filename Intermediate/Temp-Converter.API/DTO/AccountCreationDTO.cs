using System.ComponentModel.DataAnnotations;

namespace Temp_Converter.API.DTO
{
    public class AccountCreationDTO
    {
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
