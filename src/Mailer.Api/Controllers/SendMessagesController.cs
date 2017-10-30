using System.Threading.Tasks;
using Mailer.Core.Commands;
using Mailer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    public class SendMessagesController : Controller
    {
        private readonly ISmtpService _smtpService;

        public SendMessagesController(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }

        [Route("/api/smtp/send")]
        [HttpPost]
        public async Task<IActionResult> Send([FromBody]SendMessage command)
        {
            await _smtpService.SendMessage(command.ToAddress,
                command.Subject, command.Body);

            return Created($"done",null);
        }
    }
}