using Microsoft.EntityFrameworkCore;
using VotingSystem.DataAccess.DataContext;
using VotingSystem.Domain.Models;

namespace VotingSystem.DataAccess.Utilities
{
    public class DatabaseModelValidator
    {
        private  readonly VotingSystemContext database;

        public DatabaseModelValidator(VotingSystemContext database)
        {
            this.database = database;
        }

        public async Task<bool> CheckExistingNameAndEmailOnCandidates(string firstname, string lastname, string email)
        {
            try
            {
                var credentialsCheck = await database.Candidates
                    .AnyAsync(x=> x.FirstName.ToLower() + x.LastName.ToLower() == firstname.ToLower() + lastname.ToLower() 
                    && x.Email.ToLower() == email.ToLower());

                if (credentialsCheck)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<bool> CheckExistingEmailForUserProfile(string email)
        {
            try
            {
                var credentialsCheck = await database.UserProfiles
                    .AnyAsync(x =>x.Email.ToLower() == email.ToLower());

                if (credentialsCheck)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }  
        public async Task<Candidate> CheckCanditateByID(int id)
        {
            try
            {
                var credentials = await database.Candidates
                    .FirstOrDefaultAsync(x =>x.Id == id);

                if (credentials is not null)
                {
                    return credentials;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
