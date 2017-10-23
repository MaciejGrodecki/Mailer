using System.Threading.Tasks;
using Mailer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    [Route("")]
    public class InboxController : Controller
    {
        private readonly IEmailService _emailService;

        public InboxController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Route("/api/inbox/count")]
        [HttpGet]
        public async Task<IActionResult> GetMessageCount()
        {
            int count = await _emailService.GetInboxMessagesCount();

            return Json(count);
        }

        [Route("/api/inbox/topics")]
        [HttpGet]
        public async Task<IActionResult> GetMessageTopics()
        {
            var topics = await _emailService.GetInboxMessagesTopics();

            return Json(topics);
        }
    }
}