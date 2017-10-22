using System.Threading.Tasks;
using Mailer.Core.Settings;
using MailKit.Net.Imap;
using Microsoft.Extensions.Options;

namespace Mailer.Core.ServerConnections
{
    public class ImapConnection
    {
        private readonly EmailConfig _emailConfig;
        public ImapConnection(IOptions<EmailConfig> emailConfig)
        {
            
            _emailConfig = emailConfig.Value;
        }


        public async Task<ImapClient> ConnectAsync()
        {
            var client = new ImapClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await client.ConnectAsync(_emailConfig.ImapServerAddress, _emailConfig.ImapPort, true);
            await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
            client.AuthenticationMechanisms.Remove("XOAUTH2");


            return client;
        }

    }
}