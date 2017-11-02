using System.Threading.Tasks;
using Mailer.Core.Services;
using MailKit;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    [Route("")]
    public class InboxController : Controller
    {
        private readonly IInboxService _inboxService;

        public InboxController(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        [Route("/api/inbox")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var messages = await _inboxService.BrowseInboxAsync();

            return Json(messages);
        }

        [Route("/api/inbox/count")]
        [HttpGet]
        public async Task<IActionResult> GetMessageCount()
        {
            int count = await _inboxService.GetInboxMessagesCountAsync();

            return Json(count);
        }

        [Route("/api/inbox/topics")]
        [HttpGet]
        public async Task<IActionResult> GetMessageTopics()
        {
            var topics = await _inboxService.GetInboxMessagesTopicsAsync();

            return Json(topics);
        }

        [Route("/api/inbox/unread/count")]
        [HttpGet]
        public async Task<IActionResult> GetUnreadMessagesCount()
        {
            int count = await _inboxService.GetNumberOfUnreadMessagesAsync();

            return Json(count);
        }

        [Route("/api/inbox/{messageId}")]
        [HttpGet]
        public async Task<IActionResult> GetMessage(uint messageId)
        {
            var message = await _inboxService.GetMessage(messageId);

            return Json(message);
        }
    }
}