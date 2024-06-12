using System.Text;

namespace VotingSystem.DataAccess.Utilities
{
    public static class RandomValueGenerator
    {
        private static StringBuilder builder = new StringBuilder(11);
        private static string randomCharacters = "abcdefghijklmnopqrstuvwxyz0123456789"; 
        private static Random random = new Random();
        public static string GenerateRandomUserCode(string usertype)
        {
            if(usertype == null)
            {
                throw new ArgumentNullException(nameof(usertype));
            }
            else if (usertype is "Voter" || usertype is "Candidate")
            {
                for (int i = 0; i < 11; i++)
                {
                    builder.Append(randomCharacters[random.Next(randomCharacters.Length)]);
                }

                var generatedCode = builder.ToString();

                var userCode = usertype.Substring(0, 3).ToLower() + generatedCode;

                return userCode;
            }
            else
            {
                throw new ArgumentException("Invalid user type");

            }
        }
    }
}
