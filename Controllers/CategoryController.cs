using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get([FromServices] DataContext context)
        {
            try

            {
                IEnumerable<Category> categories = await context.Categories.AsNoTracking().ToListAsync();
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível buscar a lista de categorias." });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id, [FromBody] Category category, [FromServices] DataContext context)
        {
            try
            {
                var categorydb = await context.Categories.FirstOrDefaultAsync(category => category.Id == id);

                if (categorydb == null)
                    return NotFound(new { message = "Não foi encontrada nenhuma categoria." });

                return Ok(categorydb);

            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível buscar a categoria." });
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromBody] Category category, [FromServices] DataContext context)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    category.Id = 0;
                    context.Categories.Add(category);
                    await context.SaveChangesAsync();
                    return Ok(category);
                }
                catch (Exception e)
                {
                    return BadRequest(new { message = e.Message + "Não foi possível inserir a categoria." });
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category category, [FromServices] DataContext context)
        {

            if (category.Id != id)
                return NotFound(new { message = "Categoria não encontrada." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(category).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível alterar a categoria" });
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id, [FromServices] DataContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(categoria => categoria.Id == id);

            if (category == null)
            {
                return NotFound(new { message = "Nenhuma categoria foi localizada." });
            }

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria deleta." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível deletar a categoria." });
            }


        }
    }
}