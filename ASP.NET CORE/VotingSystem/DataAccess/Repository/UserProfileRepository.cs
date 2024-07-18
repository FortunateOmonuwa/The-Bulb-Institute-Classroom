using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VotingSystem.DataAccess.DataContext;
using VotingSystem.DataAccess.Interfaces;
using VotingSystem.DataAccess.Utilities;
using VotingSystem.Domain.DTOs.UserProfiles;
using VotingSystem.Domain.Models;

namespace VotingSystem.DataAccess.Repository
{

    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly VotingSystemContext database;
        private readonly DatabaseModelValidator validator;
        public UserProfileRepository(VotingSystemContext database, DatabaseModelValidator validator)
        {
            this.database = database;
            this.validator = validator;
        }
        public async Task<int> CreateProfile(UserProfileCreateDTO profile)
        {
            try
            {
                var check_userprofile_for_email = await validator.CheckExistingEmailForUserProfile(profile.Email);
                if (check_userprofile_for_email == false)
                {
                    return 0;
                }
                var userProfile = new UserProfile()
                {
                    Email = profile.Email,
                    UserCode = RandomValueGenerator.GenerateRandomUserCode(profile.UserType),
                    UserType = profile.UserType,
                    Name = profile.FirstName + profile.LastName,
                    PasswordHash = DataEncryption.EncryptPasswordUsingBcrypt(profile.Password),

                };
             await  database.UserProfiles.AddAsync(userProfile);
            return await database.SaveChangesAsync();
             
            }
            catch
            {
                return -1;
            }

          
        }

        public async Task<UserProfile> GetProfile(string email)
        {
            try
            {
                var profiile = await database.UserProfiles.FirstOrDefaultAsync(x => x.Email == email);
                if (profiile == null)
                {
                    return null;
                }
                else
                {
                    return profiile;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
