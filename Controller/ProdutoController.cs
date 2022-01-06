using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P2SWII_API.Data;
using P2SWII_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace P2SWII_API.Controller
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {   
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get ([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task <ActionResult<Produto>> GetById ([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.Include(x => x.Usuario)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);
            return produto;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post ([FromServices] DataContext context, [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

       [HttpDelete]
       [Route("")]
       public async Task<ActionResult<Produto>> Delete ([FromServices] DataContext context, [FromBody] Produto model, [FromRoute] int id)
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
