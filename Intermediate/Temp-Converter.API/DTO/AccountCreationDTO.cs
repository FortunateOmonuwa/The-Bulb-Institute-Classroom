using System.ComponentModel.DataAnnotations;

namespace Temp_Converter.API.DTO
{
    public class AccountCreationDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Length(10, 10)]
        public string AccountNumber { get; set; }
    }
}
