
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using UserManagementApi.DTOS;
using UserManagementApi.Utilities;

namespace UserManagementApi.Service
{
    public class EmailService : IEmailService
    {
        //Congfiguration
        private readonly AppSettings _settings;
        public EmailService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task<ResponseModel<string>> SendMail(MailRequest mail)
        {

            try
            {
                var response = new ResponseModel<string>();

                //Use MimeKit to construct mail

                var message = new MimeMessage
                {
                    To = { MailboxAddress.Parse(mail.Reciever) },
                    Sender = MailboxAddress.Parse(_settings.Sender),
                    Subject = mail.Subject,
                    Body = new TextPart(TextFormat.Html)
                    {
                        Text = mail.Body
                    }
                   
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(_settings.Server, _settings.Port);
                    client.Authenticate(_settings.Sender, _settings.Password);
                    await client.SendAsync(message);
                    client.Disconnect(true);

                   

                }
                return response.SuccessResultData("Mail was sent successfully");
            }
            catch
            {
                throw;
            }
        }
    }
}
