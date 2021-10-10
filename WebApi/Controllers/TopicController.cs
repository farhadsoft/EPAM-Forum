using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService topicService;

        public TopicController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<TopicModel>> GetAll()
        {
            var result = topicService.GetAll();
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TopicModel>> GetById(int id)
        {
            var result = await topicService.GetByIdAsync(id);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] TopicModel topicModel)
        {
            await topicService.AddAsync(topicModel);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Administrator, Moderator")]
        public async Task<ActionResult> Update(TopicModel topicModel)
        {
            await topicService.UpdateAsync(topicModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            await topicService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
