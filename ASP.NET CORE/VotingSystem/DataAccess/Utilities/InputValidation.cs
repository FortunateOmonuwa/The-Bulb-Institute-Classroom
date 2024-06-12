using System.Text.RegularExpressions;

namespace VotingSystem.DataAccess.Utilities
{
    public static partial class InputValidation
    {
        public static bool FormatValidationForFirstNameLastNameAndEmail(string firstname, string lastname)
        {
            if(firstname == null || lastname == null)
            {
                return false;
            }
            else if (!FirstNameRegex().IsMatch(firstname) || !FirstNameRegex().IsMatch(lastname))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        [GeneratedRegex("^[a-zA-Z]+$")]
        private static partial Regex FirstNameRegex();
        [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\r\n")]
        private static partial Regex EmailRegex();
    }
}
