using System.Threading.Tasks;
using Mailer.Core.ServerConnections;
using Mailer.Core.Settings;
using MailKit;
using MailKit.Net.Imap;
using Microsoft.Extensions.Options;

namespace Mailer.Core.Services
{
    public class EmailService : IEmailService
    {
        
        private readonly ImapConnection imapConnection;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            imapConnection = new ImapConnection(emailConfig);
        }

        public async Task<int> InboxCount()
        {
            using(var client = await imapConnection.ConnectAsync())
            {
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                return inbox.Count;
            }
        }

        


    }
}