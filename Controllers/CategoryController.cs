using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id, [FromBody] Category category)
        {

            return Ok(category);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
                return Ok();
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category category)
        {
            if (category.Id != id)
                return NotFound(new { message = "Category not found." });

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(category);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {

            return Ok();
        }
    }
}