using System.Threading.Tasks;

namespace MailWithAzureTwilioSendGrid.Interfaces
{
    public interface IMailer
    {
        void Initialize();

        Task<bool> SendMail();

        void SetReceiverMailId(string email, string accountName);

        void SetSubject(string subject);

        void AddContent(string msg, string url = null);
    }
}