using Microsoft.AspNetCore.Mvc;

namespace ProdutosComAutenticacaoJWT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        // Aqui você pode injetar o serviço de autenticação e o contexto do banco de dados, se necessário.
        // private readonly IAuthenticationService _authService;
        // private readonly ApiDbContext _context;
        public AuthController()
        {
            // _authService = authService;
            // _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserViewModel model)
        {
            return Ok();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserViewModel model)
        {
            return Ok();
        }
    }
    {
    }
}
