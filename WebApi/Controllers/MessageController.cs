using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        private readonly UserManager<IdentityUser> userManager;

        public MessageController(IMessageService messageService, UserManager<IdentityUser> userManager)
        {
            this.messageService = messageService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<MessageModel>> GetAll()
        {
            string userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = messageService.GetAll(userEmail);
            return result is not null ? Ok(result) : NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] MessageSendModel message)
        {
            var userExist = await userManager.FindByEmailAsync(message.Receiver);
            if (userExist is null)
            {
                return NotFound();
            }

            string userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await messageService.AddAsync(message, userEmail);
            return Ok();
        }
    }
}
