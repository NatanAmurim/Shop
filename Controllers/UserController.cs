using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post([FromBody] User user, [FromServices] DataContext context)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userTemp = await context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);

                    if (userTemp != null)
                        return BadRequest(new { message = "Usuário já cadastrado." });

                    user.Id = 0;
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    return Ok(new { message = "Usuário cadastrado com sucesso." });
                }
                catch (Exception)
                {
                    return BadRequest(new { message = "Não foi possível cadastrar o usuário." });
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<User>> PutUserName([FromBody] User user, [FromServices] DataContext context)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userTemp = await context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);

                    if (userTemp == null)
                        return BadRequest(new { message = "Usuário não encontrado" });

                    if (userTemp.Password != user.Password)
                        return BadRequest(new { message = "Senha incorreta." });

                    context.Entry<User>(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest(new { message = "Nao foi possível atualizar o usuário." });
                }

            }

            return BadRequest();
        }
    }
}