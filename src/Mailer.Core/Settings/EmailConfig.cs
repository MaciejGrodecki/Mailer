namespace Mailer.Core.Settings
{
    public class EmailConfig
    {
        public string ImapServerAddress { get; set; }
        public int ImapPort { get; set; }
        public string UserName { get; set; }

        public string SmtpServerAddress {get; set;}
        public int SmtpPort { get; set; }
    }
}