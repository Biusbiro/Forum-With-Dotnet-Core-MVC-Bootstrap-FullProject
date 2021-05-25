using System.Collections.Generic;
using System.Threading.Tasks;
using Forum_API_BackEnd.Data;
using Forum_API_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum_API_BackEnd.Controllers
{
    [ApiController]
    [Route("v1/posts")]
    public class PostController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Post>>> GetAction([FromServices] DataContext context)
        {
            var posts = await context.Posts.ToListAsync();
            return posts;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Post>> Post(
            [FromServices] DataContext context,
            [FromBody]Post model)
        {
            if (ModelState.IsValid)
            {
                context.Posts.Add(model);
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