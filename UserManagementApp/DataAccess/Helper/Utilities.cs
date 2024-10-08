namespace UserManagementApp.DataAccess.Helper
{
    public static class Utilities
    {
        public static string EncryptPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cant be null or empty");
            }
            else
            {
                var hashPass = BCrypt.Net.BCrypt.HashPassword(password);
                return hashPass;
            }
        }

        public static string GenerateUsername(string username)
        {
            string transform = username.Replace('a', '@').Replace('e', '$');

            var generatedUsername = transform.Substring(0, 5);
            return generatedUsername;
                 
        }

        public static bool DecrytPassword(string password,string paswordHash) 
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new Exception("Password is incorrect");

            }
            var validation = BCrypt.Net.BCrypt.Verify(password, paswordHash);
            return validation;
        }
    }
}
