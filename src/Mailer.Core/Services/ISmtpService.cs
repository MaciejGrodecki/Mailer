using System.Threading.Tasks;

namespace Mailer.Core.Services
{
    public interface ISmtpService
    {
        Task SendMessage(string toAddress, string subject, string body);
    }
}