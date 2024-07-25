using VotingSystem.Domain.DTOs.LoginDTO;

namespace VotingSystem.DataAccess.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(Login login);
    }
}
