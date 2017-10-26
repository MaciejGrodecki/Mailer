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


        public async Task SendMessage(string myAddress, string toAddress, 
            string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(
                new MailboxAddress("Maciek", myAddress)
            );
            message.To.Add(
                new MailboxAddress("Maciek2", toAddress)
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