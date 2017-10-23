using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Core.DTO;
using MimeKit;

namespace Mailer.Core.Services
{
    public interface IInboxService
    {
        Task<int> GetInboxMessagesCount();
        Task<ICollection<EmailDto>> BrowseInbox();
        Task<ICollection<string>> GetInboxMessagesTopics();

    }
}