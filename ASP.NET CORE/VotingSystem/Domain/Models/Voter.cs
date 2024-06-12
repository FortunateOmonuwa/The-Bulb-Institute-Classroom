using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain.Models
{
    public class Voter
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required, DataType(DataType.Text), Length(3, 20)]
        public string FirstName { get; set; } = "";
        [Required, DataType(DataType.Text), Length(3, 20)]
        public string LastName { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string Address { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string VotersCardNumber { get; set; } = "";
    }
}
