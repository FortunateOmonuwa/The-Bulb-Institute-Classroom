using InventoryManagementAPI.DTOs.Mail;
using InventoryManagementAPI.Helper;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace InventoryManagementAPI.Service
{
    public class EmailService(IOptions<BaseSetup> setup) : IEmailService
    {   private readonly BaseSetup _setup = setup.Value;

        public async Task<ResponseModel<string>> SendEmailAsync(MailRequest mail)
        {
            try
            {
                var response = new ResponseModel<string>();

                //MimeKit 
                var message = new MimeMessage
                {
                    To = {MailboxAddress.Parse(mail.Reciever)},
                    Sender = MailboxAddress.Parse(_setup.Sender),
                    Subject = mail.Subject,
                    Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = mail.Body
                    }
                    
                };
                //Inject SmtpClient
                    using(var client = new SmtpClient())
                {
                    client.Connect(_setup.Server, _setup.Port);
                    client.Authenticate(_setup.Sender, _setup.Password);
                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
                return response.SuccessResult("Mail was sent successfully");
            }
            catch 
            {
                throw;
            }
        }
    }
}
