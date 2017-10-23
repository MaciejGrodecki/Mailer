using System.Collections.Generic;
using MailKit;
using MimeKit;

namespace Mailer.Core.DTO
{
    public class EmailDto
    {
        public UniqueId EmailId { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public IEnumerable<MimeEntity> Attachments { get; set; }
    }
}