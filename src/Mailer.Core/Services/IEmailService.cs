using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Core.DTO;

namespace Mailer.Core.Services
{
    public interface IEmailService
    {
        Task<int> GetInboxMessagesCount();
        Task<ICollection<string>> GetInboxMessagesTopics();
    }
}