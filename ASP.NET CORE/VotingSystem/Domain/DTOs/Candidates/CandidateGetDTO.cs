using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain.DTOs.Candidates
{
    public class CandidateGetDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string UserCode { get; set; } = "";
    }
}
