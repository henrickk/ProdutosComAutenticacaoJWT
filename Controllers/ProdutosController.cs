using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosComAutenticacaoJWT.Data;
using ProdutosComAutenticacaoJWT.Models;

namespace ProdutosComAutenticacaoJWT.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ProdutosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("buscar-produtos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet]
        [Route("buscar-produtoPorId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produto>> BuscarProdutoPorId(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost]
        [Route("adicionar-produto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = produto.Id }, produto);
        }

        [HttpPut]
        [Route("atualizar-produto/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarProduto(int id, Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
                
        }

        [HttpDelete]
        [Route("deletar-produto/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
