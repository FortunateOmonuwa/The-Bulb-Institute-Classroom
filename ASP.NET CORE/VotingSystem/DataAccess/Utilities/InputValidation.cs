using System.Text.RegularExpressions;

namespace VotingSystem.DataAccess.Utilities
{
    public static partial class InputValidation
    {
        public static bool FormatValidationForFirstNameLastNameAndEmail(string firstname, string lastname, string email)
        {
           if (FirstNameRegex().IsMatch(firstname) && FirstNameRegex().IsMatch(lastname) && EmailRegex().IsMatch(email))
            {
                return true;
            }
    
            else
            {
                return false;
            }
            
        }

        [GeneratedRegex("^[a-zA-Z]+$")]
        private static partial Regex FirstNameRegex();
        [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
        private static partial Regex EmailRegex();

    }
}
