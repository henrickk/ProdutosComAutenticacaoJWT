using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosComAutenticacaoJWT.Data;
using ProdutosComAutenticacaoJWT.Models;

namespace ProdutosComAutenticacaoJWT.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController
    {
        private readonly ApiDbContext _context;
        public ProdutosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("BuscarProdutos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
