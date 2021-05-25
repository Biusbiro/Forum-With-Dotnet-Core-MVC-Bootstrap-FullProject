using System.Collections.Generic;
using System.Threading.Tasks;
using Forum_API_BackEnd.Data;
using Forum_API_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum_API_BackEnd.Controllers
{
    [ApiController]
    [Route("v1/subcathegories")]
    public class SubcathegoriesController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Subcathegory>>> GetAction([FromServices] DataContext context)
        {
            var subcathegories = await context.Subcathegories.ToListAsync();
            return subcathegories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Subcathegory>> Post(
            [FromServices] DataContext context,
            [FromBody]Subcathegory model)
        {
            if (ModelState.IsValid)
            {
                context.Subcathegories.Add(model);
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