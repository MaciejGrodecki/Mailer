namespace Mailer.Core.Commands
{
    public class SendMessage
    {
        public string MyAddress { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}