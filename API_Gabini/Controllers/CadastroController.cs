using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Gabini.Controllers    
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly AuthService _authService;

        public CadastroController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Usuario usuario)
        {
            var result = await _authService.Register(usuario);
            if (result == "Usuário já registrado!")
                return Conflict(result);
            return Ok(result);
        }
    }
}
