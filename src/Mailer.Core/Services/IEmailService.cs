using System.Threading.Tasks;

namespace Mailer.Core.Services
{
    public interface IEmailService
    {
        Task<int> InboxCount();
    }
}