using System.Collections.Generic;
using System.Threading.Tasks;
using Forum_API_BackEnd.Data;
using Forum_API_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum_API_BackEnd.Controllers
{
    [ApiController]
    [Route("v1/topics")]
    public class TopicController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Topic>>> GetAction([FromServices] DataContext context)
        {
            var topics = await context.Topics.ToListAsync();
            return topics;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Topic>> Post(
            [FromServices] DataContext context,
            [FromBody]Topic model)
        {
            if (ModelState.IsValid)
            {
                context.Topics.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}