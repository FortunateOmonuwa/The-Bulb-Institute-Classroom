using VotingSystem.DataAccess.DataContext;
using VotingSystem.DataAccess.Interfaces;
using VotingSystem.DataAccess.Utilities;
using VotingSystem.Domain.DTOs.Candidates;
using VotingSystem.Domain.DTOs.UserProfiles;
using VotingSystem.Domain.Models;

namespace VotingSystem.DataAccess.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly VotingSystemContext database;
        private readonly DatabaseModelValidator validator;
        private readonly IUserProfileRepository profile;
        public CandidateRepository(VotingSystemContext database, DatabaseModelValidator validator, IUserProfileRepository profile )
        {
            this.database = database;
            this.validator = validator;
            this.profile = profile;
        }

        public async Task<CandidateGetDTO> CreateCandidate(CandidateCreateDTO new_candidate)
        {
           // var transaction = await database.Database.BeginTransactionAsync();
            try
            {
                //to check if the firstname, lastnmae or email is in the right format
                var input_validation = InputValidation
                    .FormatValidationForFirstNameLastNameAndEmail(new_candidate.FirstName, new_candidate.LastName, new_candidate.Email);
                if (input_validation == false)
                {
                    throw new FormatException("Wrong format for credentials");
                }
                else
                {
                    //to check if the candidate exists
                    var checkdb_for_name_and_email = await validator
                        .CheckExistingNameAndEmailOnCandidates(new_candidate.FirstName, new_candidate.LastName, new_candidate.Email);
                    if(checkdb_for_name_and_email == false)
                    {
                        throw new Exception();
                    }

                    var newCandidate = new Candidate()
                    {
                        Email = new_candidate.Email,
                        FirstName = new_candidate.FirstName,
                        LastName = new_candidate.LastName,
                        
                    };
                    await database.Candidates.AddAsync(newCandidate);
                    var candidate_creation_response = await database.SaveChangesAsync();
                    if(candidate_creation_response < 1)
                    {
                        throw new Exception("Saving candidate to database was not successful");
                    }
      
                    var userProfile = new UserProfileCreateDTO()
                    {
                        Email = newCandidate.Email,
                       // UserCode = "Candidate",
                        UserType = "Candidate",
                        FirstName = newCandidate.FirstName,
                        LastName = newCandidate.LastName,
                        Password = DataEncryption.EncryptPasswordUsingBcrypt(new_candidate.Password),              
                    };

                    var userprofile_creation_response = await profile.CreateProfile(userProfile);
                    //Deletes candidate if the creation of userprofile for the candidate is unsuccessful
                    if(userprofile_creation_response < 1)
                    {
                      await DeleteCandidate(newCandidate.Id);
                        throw new Exception("Saving userprofile to database was not successful");
                    }
                 //   await transaction.CommitAsync();
                    var candidate = new CandidateGetDTO()
                    {
                        Id = newCandidate.Id,
                        Email = newCandidate.Email,
                        Name = newCandidate.FirstName + newCandidate.LastName,
                        Code = userProfile.UserCode
                       
                    };

                    return candidate;
                }

            }
            catch(Exception ex)
            {
               // await transaction.RollbackAsync();
                throw new Exception(ex.Message);

            }
        }

        public async Task<bool> DeleteCandidate(int candidate_id)
        {
            try
            {
                var candidate = await validator.CheckCanditateByID(candidate_id);
                if(candidate is null)
                {
                    return false;
                }
                else
                {
                    database.Candidates.Remove(candidate);
                    await database.SaveChangesAsync();
                    return true;
                    
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CandidateGetDTO> GetCandidateByID(int candidate_id)
        {
            try
            {
                var candidate = await validator.CheckCanditateByID(candidate_id);
                if( candidate is null)
                {
                    return null;
                }
                else
                {
                    var userProfile = await profile.GetProfile(candidate.Email);
                    var fetchedCandidate = new CandidateGetDTO
                    {
                        Id = candidate.Id,
                        Email = candidate.Email,
                        Name = candidate.FirstName + candidate.LastName,
                        Code = userProfile.UserCode,
                        Type = userProfile.UserType

                    };
                    return fetchedCandidate;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Candidate>> GetAllCandidates(CandidateCreateDTO new_candidate)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> UpdateCandidate(Candidate candidate_to_update)
        {
            throw new NotImplementedException();
        }
    }
}
