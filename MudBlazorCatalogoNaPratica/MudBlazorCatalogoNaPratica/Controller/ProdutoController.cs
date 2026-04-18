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
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get([FromQuery] Paginacao paginacao)
        {
            var queryable = _context.Produtos
                .Include(p => p.Categoria)
                .AsQueryable();

            if (!string.IsNullOrEmpty(paginacao.TermoBusca))
            {
                queryable = queryable.Where(x => x.Nome.ToLower().Contains(paginacao.TermoBusca.ToLower()) ||
                                                x.Descricao.ToLower().Contains(paginacao.TermoBusca.ToLower()));
            }

            await HttpContext.InserirParametroEmPageResonse(queryable, paginacao.QuantidadePorPagina);

            return await queryable.OrderByDescending(x => x.ProdutoId).Paginar(paginacao).ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(x => x.ProdutoId == id);
            
            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("O ID da URL não coincide com o ID do produto.");
            }

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            produto.Categoria = await _context.Categorias.FindAsync(produto.CategoriaId);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}

