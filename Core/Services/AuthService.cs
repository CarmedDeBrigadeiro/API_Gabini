using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Register([FromBody] Usuario usuario)
        {
            var sucesso = await _authService.Register(usuario);
            return sucesso ? Ok("Usuário registrado com sucesso!") : BadRequest("Erro ao registrar o usuário.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var sucesso = await _authService.Login(loginRequest);
            return sucesso ? Ok("Login realizado com sucesso!") : Unauthorized("Credenciais inválidas.");
        }
    }
}
