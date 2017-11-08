using System.Threading.Tasks;
using Mailer.Core.Settings;
using MailKit.Net.Imap;
using Microsoft.Extensions.Options;

namespace Mailer.Core.ServerConnections
{
    public class ImapConnection : IImapConnection
    {
        private readonly EmailConfig _emailConfig;
        private readonly EmailSecrets _emailSecrets;

        public ImapConnection(IOptions<EmailConfig> emailConfig, IOptions<EmailSecrets> emailSecrets)
        {
            
            _emailConfig = emailConfig.Value;
            _emailSecrets = emailSecrets.Value;
        }


        public async Task<ImapClient> ConnectAsync()
        {
            var client = new ImapClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await client.ConnectAsync(_emailConfig.ImapServerAddress, _emailConfig.ImapPort, true);
            await client.AuthenticateAsync(_emailConfig.UserName, _emailSecrets.Password);
            client.AuthenticationMechanisms.Remove("XOAUTH2");


            return client;
        }

    }
}