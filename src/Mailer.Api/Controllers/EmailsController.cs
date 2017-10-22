using System.Threading.Tasks;
using Mailer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    [Route("")]
    public class EmailsController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Route("/api/inbox/count")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int count = await _emailService.InboxCount();

            return Json(count);
        }
    }
}