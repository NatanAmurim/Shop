using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Category> getCategories()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Category> GetById(int id, [FromBody] Category category)
        {
            category.Title = "Amor";
            return Ok(category);
        }

        [HttpPut]
        public ActionResult<Category> Update(int id, [FromBody] Category category)
        {
            return Ok(category);
        }
    }
}