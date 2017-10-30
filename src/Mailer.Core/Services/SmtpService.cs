using System.Threading.Tasks;
using Mailer.Core.ServerConnections;
using MimeKit;

namespace Mailer.Core.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly ISmtpConnection _smtpConntection;

        public SmtpService (ISmtpConnection smtpConnection)
        {
            _smtpConntection = smtpConnection;
        }


        public async Task SendMessage(string toAddress, 
            string subject, string body)
        {
            
            var message = new MimeMessage();
            message.From.Add(
                new MailboxAddress(_smtpConntection.GetEmailAddress(), _smtpConntection.GetEmailAddress())
            );
            message.To.Add(
                new MailboxAddress(toAddress, toAddress)
            );

            message.Subject = subject;

            message.Body = new TextPart("plain"){Text = body};

            using(var client = await _smtpConntection.ConnectAsync())
            {
                await client.SendAsync(message);
            }
            
        }
    }
}