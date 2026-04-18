using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazorCatalogoNaPratica.Context;
using MudBlazorCatalogoNaPratica.Shared.Models;
using MudBlazorCatalogoNaPratica.Shared.Recursos;
using MudBlazorCatalogoNaPratica.Utils;

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

        [HttpGet("all")]
        public async Task<ActionResult<List<Categoria>>> GetAll()
        {
            return await context.Categorias
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get([FromQuery] Paginacao paginacao)
        {
            var queryable = context.Categorias.AsQueryable();

            if (!string.IsNullOrEmpty(paginacao.TermoBusca))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(paginacao.TermoBusca.ToLower()) ||
                                                x.Descricao.ToLower().Contains(paginacao.TermoBusca.ToLower()));
            }

            await HttpContext.InserirParametroEmPageResonse(queryable, paginacao.QuantidadePorPagina);

            return await queryable.Paginar(paginacao).ToListAsync();
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

