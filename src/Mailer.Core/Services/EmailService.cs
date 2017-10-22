using System.Threading.Tasks;
using Mailer.Core.Settings;
using MailKit;
using MailKit.Net.Imap;
using Microsoft.Extensions.Options;

namespace Mailer.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _emailConfig;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task<int> InboxCount()
        {
            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_emailConfig.ImapServerAddress, _emailConfig.ImapPort, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                return inbox.Count;
            }
        }


    }
}