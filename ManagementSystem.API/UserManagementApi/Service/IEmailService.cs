using UserManagementApi.DTOS;
using UserManagementApi.Utilities;

namespace UserManagementApi.Service
{
    public interface IEmailService
    {
        Task<ResponseModel<string>> SendMail(MailRequest mail);
       
    }
}
