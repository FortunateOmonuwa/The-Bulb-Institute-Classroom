using VotingSystem.Domain.DTOs.UserProfiles;
using VotingSystem.Domain.Models;

namespace VotingSystem.DataAccess.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<int> CreateProfile(UserProfileCreateDTO profile);
        Task<UserProfile> GetProfile(string email);
    }
}
