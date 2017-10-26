using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mailer.Core.Domain;
using Mailer.Core.DTO;
using Mailer.Core.ServerConnections;
using Mailer.Core.Settings;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Mailer.Core.Services
{
    public class InboxService : IInboxService
    {
        
        private readonly IImapConnection _imapConnection;
        private readonly IMapper _mapper;

        public InboxService(IImapConnection imapConnection, IMapper mapper)
        {
            _imapConnection = imapConnection;
            _mapper = mapper;
        }

        public async Task<ICollection<EmailDto>> BrowseInboxAsync()
        {
            var inboxMessages = new List<Email>();
            using(var client = await _imapConnection.ConnectAsync())
            {
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                var uids = await inbox.SearchAsync(SearchQuery.All);

                foreach(var uid in uids)
                {
                    var message = await client.Inbox.GetMessageAsync(uid);
                    inboxMessages.Add(
                        new Email(uid, message.Subject, message.TextBody, message.Attachments)
                    );
                }

                return _mapper.Map<ICollection<EmailDto>>(inboxMessages);
            }
        }

        public async Task<int> GetInboxMessagesCountAsync()
        {
            using(var client = await _imapConnection.ConnectAsync())
            {
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                return inbox.Count;
            }
        }

        public async Task<ICollection<string>> GetInboxMessagesTopicsAsync()
        {
            var inboxMessages = new List<string>();
            using(var client = await _imapConnection.ConnectAsync())
            {
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                var uids = await inbox.SearchAsync(SearchQuery.All);
                
                foreach(var uid in uids)
                {
                    var message = await client.Inbox.GetMessageAsync(uid);
                    inboxMessages.Add(message.Subject);
                }

                return inboxMessages;
                
            }
            
        }

        public async Task<int> GetNumberOfUnreadMessagesAsync()
        {
            using(var client = await _imapConnection.ConnectAsync())
            {
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);
                
                
                return inbox.Unread;
            }
        }
    }
}