using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2SWII_API.Models;
using P2SWII_API.Data;

namespace P2SWII_API.Controller
{
    [ApiController]
    [Route("v1/Usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Usuario>>> Get ([FromServices] DataContext context)
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return usuarios;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post(
            [FromServices] DataContext context,
            [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                context.Usuarios.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Usuario>> Put ([FromServices] DataContext context,
            [FromBody] Usuario model,
            [FromRoute] int id)
        {
            if(!ModelState.IsValid)            
                return BadRequest();
            

            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.id == id);

            if(usuario == null)            
                return NotFound();
            

            try
            {
                usuario.Nome = model.Nome;
                usuario.Senha = model.Senha;
                usuario.Status = model.Status;

                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<Usuario>> Delete([FromServices] DataContext context, [FromBody] Usuario model, [FromRoute] int id)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.id == id);

            try
            {
                context.Produtos.Remove(produto);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
        }

    }
}
