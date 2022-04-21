using MailWithAzureTwilioSendGrid.Interfaces;

namespace MailWithAzureTwilioSendGrid.Core
{
    public class MailConfig : IMailConfig
    {
        public string ApiKey { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
    }
}