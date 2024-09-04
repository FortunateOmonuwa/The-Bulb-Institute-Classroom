using InventoryManagementAPI.DTOs.Mail;
using InventoryManagementAPI.Helper;

namespace InventoryManagementAPI.Service
{
    public interface IEmailService
    {
        Task<ResponseModel<string>> SendEmailAsync(MailRequest mail);
    }
}
