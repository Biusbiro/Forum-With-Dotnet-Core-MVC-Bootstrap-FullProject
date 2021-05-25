using System.Collections.Generic;
using System.Threading.Tasks;
using Forum_API_BackEnd.Data;
using Forum_API_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum_API_BackEnd.Controllers
{
    [ApiController]
    [Route("v1/cathegories")]
    public class CathegoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cathegory>>> GetAction([FromServices] DataContext context)
        {
            var cathegories = await context.Cathegories.ToListAsync();
            return cathegories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cathegory>> Post(
            [FromServices] DataContext context,
            [FromBody]Cathegory model)
        {
            if (ModelState.IsValid)
            {
                context.Cathegories.Add(model);
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