using System.Collections.Generic;
using System.Threading.Tasks;
using Forum_API_BackEnd.Data;
using Forum_API_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum_API_BackEnd.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class CathegorController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> GetAction([FromServices] DataContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody]User model)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(model);
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