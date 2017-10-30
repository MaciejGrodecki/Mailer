namespace Mailer.Core.Commands
{
    public class SendMessage
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}