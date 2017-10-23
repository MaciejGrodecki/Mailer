using System;
using System.Collections.Generic;
using MailKit;
using MimeKit;

namespace Mailer.Core.Domain
{
    public class Email
    {
        public UniqueId EmailId { get; protected set; }
        public string Topic { get; protected set; }
        public string Body { get; protected set; }
        public IEnumerable<MimeEntity> Attachments { get; protected set; }

        protected Email()
        {
        
        }

        public Email(UniqueId emailId, string topic, string body)
        {
            EmailId = emailId;
            SetTopic(topic);
            SetBody(body);
            
        }

        public Email(UniqueId emailId, string topic, string body, 
            IEnumerable<MimeEntity> attachments)
        {
            EmailId = emailId;
            SetTopic(topic);
            SetBody(body);
            Attachments = attachments;
            
        }

        public void SetTopic(string topic)
        {
            if(String.IsNullOrEmpty(topic))
            {
                throw new Exception("The topic is null");
            }
            Topic = topic;
        }

        public void SetBody(string body)
        {
            if(String.IsNullOrEmpty(body))
            {
                throw new Exception("The body is null");
            }
            Body = body;
        }
    }
}