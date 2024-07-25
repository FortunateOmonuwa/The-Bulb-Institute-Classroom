using VotingSystem.Domain.DTOs.Candidates;
using VotingSystem.Domain.Models;

namespace VotingSystem.DataAccess.Interfaces
{
    public interface ICandidateRepository
    {
        Task<CandidateGetDTO> CreateCandidate(CandidateCreateDTO new_candidate);
        Task<CandidateGetDTO> GetCandidateByID(int candidate_id);
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<bool> DeleteCandidate(int candidate_id);
        Task<Candidate> UpdateCandidate(Candidate candidate_to_update);
    }
}
