using System.Threading.Tasks;
using Mailer.Core.Services;
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
            var messages = await _inboxService.BrowseInbox();

            return Json(messages);
        }

        [Route("/api/inbox/count")]
        [HttpGet]
        public async Task<IActionResult> GetMessageCount()
        {
            int count = await _inboxService.GetInboxMessagesCount();

            return Json(count);
        }

        [Route("/api/inbox/topics")]
        [HttpGet]
        public async Task<IActionResult> GetMessageTopics()
        {
            var topics = await _inboxService.GetInboxMessagesTopics();

            return Json(topics);
        }
    }
}