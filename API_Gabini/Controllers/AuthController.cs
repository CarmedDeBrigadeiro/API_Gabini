using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Ports.Services;

namespace API_Gabini.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Usuario usuario)
        {
            var resultado = _authService.Register(usuario);
            return resultado == "Usuário registrado com sucesso!" ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var resultado = _authService.Login(loginRequest);
            return resultado == "Login realizado com sucesso!" ? Ok(resultado) : Unauthorized(resultado);
        }
    }
}
