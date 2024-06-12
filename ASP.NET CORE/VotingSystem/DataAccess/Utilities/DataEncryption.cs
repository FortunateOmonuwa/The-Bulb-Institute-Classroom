using BCrypt.Net;

namespace VotingSystem.DataAccess.Utilities
{
    public static class DataEncryption
    {
        public static string EncryptPasswordUsingBcrypt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Password cannot be null or empty");
            }
            else
            {
                var newPassword = BCrypt.Net.BCrypt.HashPassword(password);
                return newPassword;
            }
        }
    }
}
    