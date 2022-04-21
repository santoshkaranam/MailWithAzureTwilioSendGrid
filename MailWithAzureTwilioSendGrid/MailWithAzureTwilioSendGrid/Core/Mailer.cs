using System;
using System.Net;
using System.Threading.Tasks;
using MailWithAzureTwilioSendGrid.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailWithAzureTwilioSendGrid.Core
{
    public class Mailer : IMailer
    {
        private readonly IMailConfig _mailConfig;
        private SendGridMessage _message = new SendGridMessage();

        public Mailer(IMailConfig mailConfig)
        {
            _mailConfig = mailConfig;
            Initialize();
        }

        public void Initialize()
        {
            _message = new SendGridMessage();
            _message.SetFrom(new EmailAddress(_mailConfig.EmailId, _mailConfig.Name));
        }

        public async Task<bool> SendMail()
        {
            try
            {
                SendGridClient client = new SendGridClient(_mailConfig.ApiKey);
                Response response = await client.SendEmailAsync(_message).ConfigureAwait(true);
                return response.StatusCode == HttpStatusCode.Accepted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public void SetReceiverMailId(string email, string accountName)
        {
            _message.AddTo(new EmailAddress(email, accountName));
        }

        public void SetSubject(string subject)
        {
            _message.SetSubject(subject);
        }

        public void AddContent(string msg, string url = null)
        {
            string text = $"<p>{msg}</p>\r\n<p>{url}</p>\r\n<p>&nbsp;- {_mailConfig.Name}</p>";
            _message.AddContent(MimeType.Html, text);
        }
    }
}