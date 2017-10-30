using System.Threading.Tasks;
using Mailer.Core.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace Mailer.Core.ServerConnections
{
    public class SmtpConnection : ISmtpConnection
    {
        private readonly EmailConfig _emailConfig;

        public SmtpConnection(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task<SmtpClient> ConnectAsync()
        {
            var client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s,c,h,e) => true;

            await client.ConnectAsync("smtp.gmail.com", 465, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

            return client;
        }

        public string GetEmailAddress()
        {
            return _emailConfig.UserName;
        }
    }
}