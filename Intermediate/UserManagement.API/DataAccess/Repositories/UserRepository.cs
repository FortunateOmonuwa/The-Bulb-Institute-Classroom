
using UserManagement.API.DataAccess.DataContext;
using UserManagement.API.DataAccess.Interfaces;
using UserManagement.API.Domain;
using UserManagement.API.DTOs;
using UserManagement.API.Service;
using UserManagement.API.Utilities;

namespace UserManagement.API.DataAccess.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly  IMailService mailService;
        private readonly UserContext context;
        public UserRepository(IMailService mailService, UserContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }
        public async Task<ResponseModel<User>> Register(Register new_user)
        {
            try
            {

            }
            catch
            {
                throw;
            }
        }
    }
}
