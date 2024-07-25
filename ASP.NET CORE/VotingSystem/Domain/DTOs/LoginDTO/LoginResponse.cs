namespace VotingSystem.Domain.DTOs.LoginDTO
{
    public class LoginResponse(string token = "Token", string message = "message", int statusCode = 0)
    {
        public string _token = token;
        public string _message = message;
        public int _statusCode = statusCode;
    }
}
