namespace Mailer.Core.Settings
{
    public class EmailConfig
    {
        public string ImapServerAddress { get; set; }
        public int ImapPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}