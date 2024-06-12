using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain.DTOs.Candidates
{
    public class CandidateCreateDTO
    {
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
