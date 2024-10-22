using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Services;

namespace API_Gabini.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController()
        {
            _authService = new AuthService();  // Instância temporária para o exemplo
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Core.Entities.Usuario usuario)
        {
            var resultado = _authService.Register(usuario);
            if (resultado == "Usuário já registrado!")
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            var resultado = _authService.Login(login);
            if (resultado == "Usuário ou senha inválidos!")
                return Unauthorized(resultado);

            return Ok(resultado);
        }
    }
}
