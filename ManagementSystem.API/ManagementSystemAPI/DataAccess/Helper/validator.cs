namespace ManagementSystemAPI.DataAccess.Helper
{
    public static class validator
    {
        private static Random random = new Random();
        public static string StaffUniqueNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input cannot be null or whitespace");
            }
            string abbrv = "";
            string[] words = input.Trim().Split(' ');

            if (words.Length > 1)
            {
                foreach (string word in words)
                {
                    if(!string.IsNullOrEmpty(word))
                    {
                        abbrv += char.ToUpper(word[0]);
                    }
                }
            }
            else
            {
                abbrv = input.Substring(0, Math.Min(3, input.Length)).ToUpper(); 
            }
            abbrv += random.Next(100, 1000);
            return abbrv;
        }

        public static string EncryptPassword(string password)
        {

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cant be null or empty");
            }
            else
            {
                var hashPass = BCrypt.Net.BCrypt.HashPassword(password);
                return hashPass;
            }

        }
     
        public static bool DecryptPassword(string password, string hashpass)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cant be null or empty");
            }

            return BCrypt.Net.BCrypt.Verify(password, hashpass);
        }

    }
}
