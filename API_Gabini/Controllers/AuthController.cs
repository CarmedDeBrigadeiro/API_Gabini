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
            var resultado = await _authService.Register(usuario);
            return resultado.Mensagem == "Usuário registrado com sucesso!" ? Ok(resultado) : BadRequest(resultado.Mensagem);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var resultado = await _authService.Login(loginRequest);

            // Comparando com a propriedade Mensagem, não com o objeto inteiro
            return resultado.Mensagem == "Login realizado com sucesso!" ? Ok(resultado) : Unauthorized(resultado.Mensagem);
        }
    }
}
