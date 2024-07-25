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

        public static bool DecryptPasswordUsingBcrypt(string password, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Password is incorrect");
            }
             var validation = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return validation;
           
        }
    }
}
    