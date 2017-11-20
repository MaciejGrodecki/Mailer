using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Core.DTO;
using MailKit;
using MimeKit;

namespace Mailer.Core.Services
{
    public interface IInboxService
    {
        Task<int> GetInboxMessagesCountAsync();
        Task<ICollection<EmailDto>> BrowseInboxAsync();
        Task<ICollection<string>> GetInboxMessagesTopicsAsync();
        Task<int> GetNumberOfUnreadMessagesAsync();
        Task<EmailDto> GetMessage(uint id);


    }
}