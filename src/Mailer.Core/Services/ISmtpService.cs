using System.Threading.Tasks;

namespace Mailer.Core.Services
{
    public interface ISmtpService
    {
        Task SendMessage(string myAddress, string toAddress, string subject, string body);
    }
}