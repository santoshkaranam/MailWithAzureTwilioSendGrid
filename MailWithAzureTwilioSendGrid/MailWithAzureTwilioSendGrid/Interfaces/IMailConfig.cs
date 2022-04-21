namespace MailWithAzureTwilioSendGrid.Interfaces
{
    public interface IMailConfig
    {
        string ApiKey { get; set; }

        string EmailId { get; set; }

        string Name { get; set; }
    }
}