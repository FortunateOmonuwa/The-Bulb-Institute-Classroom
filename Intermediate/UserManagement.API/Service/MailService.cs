using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using UserManagement.API.DTOs;
using UserManagement.API.Utilities;

namespace UserManagement.API.Service
{
    public class MailService : IMailService
    {
       // private readonly IConfiguration configuration;
       private readonly AppSettings _settings;
        public MailService (IOptions<AppSettings> settings)
        {
            _settings = settings.Value;

            //this.configuration = configuration;

        }
        public async Task<ResponseModel<string>> SendMail(MailRequest mail)
        {
            try
            {
                var response = new ResponseModel<string>();

                //use mimekit to construct the message/mail

                var message = new MimeMessage
                {
                    To = { MailboxAddress.Parse(mail.Receiver) },
                    Sender = MailboxAddress.Parse(_settings.Sender),
                    Subject = mail.Subject,
                    Body = new TextPart(TextFormat.Html)
                    {
                        Text = mail.Body
                    },
                };

                using var client = new SmtpClient();
                client.Connect(_settings.Server, _settings.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_settings.Sender, _settings.Password);
                await client.SendAsync(message);
                client.Disconnect(true);
                return response.SuccessResultData("Mail was successfully sent");
            }
            catch
            {
                throw;
            }
        }
    }
}
