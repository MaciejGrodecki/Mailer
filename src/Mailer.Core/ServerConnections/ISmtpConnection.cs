using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Mailer.Core.ServerConnections
{
    public interface ISmtpConnection
    {
        Task<SmtpClient> ConnectAsync();
    }
}