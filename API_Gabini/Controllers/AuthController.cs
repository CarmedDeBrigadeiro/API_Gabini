using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gabini.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController()
        {
            _authService = new AuthService();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Usuario usuario)
        {
            var resultado = _authService.Register(usuario);
            if (resultado == "Usuário registrado com sucesso!")
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            var resultado = _authService.Login(login);
            if (resultado == "Login realizado com sucesso!")
            {
                return Ok(resultado);
            }
            else
            {
                return Unauthorized(resultado);
            }
        }
    }
}
