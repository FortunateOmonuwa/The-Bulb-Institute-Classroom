using UserManagement.API.DTOs;
using UserManagement.API.Utilities;

namespace UserManagement.API.Service
{
    public interface IMailService
    {
        Task<ResponseModel<string>> SendMail(MailRequest mail);
    }
}
