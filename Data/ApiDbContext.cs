using Microsoft.EntityFrameworkCore;
using ProdutosComAutenticacaoJWT.Models;

namespace ProdutosComAutenticacaoJWT.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
