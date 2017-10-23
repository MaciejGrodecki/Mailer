using System.Threading.Tasks;
using MailKit.Net.Imap;

namespace Mailer.Core.ServerConnections
{
    public interface IImapConnection
    {
         Task<ImapClient> ConnectAsync();
    }
}