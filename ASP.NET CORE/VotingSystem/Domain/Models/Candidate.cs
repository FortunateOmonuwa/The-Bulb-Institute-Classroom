using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required, DataType(DataType.Text), Length(3, 20)]
        public string FirstName { get; set; } = "";
        [Required, DataType(DataType.Text), Length(3, 20)]
        public string LastName { get; set; } = "";
        public List<Vote>? Votes { get; set; }
        
    }
}
