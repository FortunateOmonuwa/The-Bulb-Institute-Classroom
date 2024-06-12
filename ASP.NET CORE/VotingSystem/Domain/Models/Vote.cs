using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingSystem.Domain.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Candidate))]
        public int CandidateID { get; set; }
        public int VoteCount { get; set; } = 0;

    }
}
