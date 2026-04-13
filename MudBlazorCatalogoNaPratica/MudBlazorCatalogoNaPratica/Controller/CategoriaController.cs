using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazorCatalogoNaPratica.Context;
using MudBlazorCatalogoNaPratica.Shared.Models;

namespace MudBlazorCatalogoNaPratica.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly AppDbContext context;
        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await context.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("O ID da URL não coincide com o ID da categoria.");
            }
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = new Categoria { CategoriaId = id };
            context.Remove(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
    }
}

