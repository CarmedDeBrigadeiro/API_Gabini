using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Gabini.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var usuario = await _userService.GetUserByIdAsync(id);  // Alteração aqui

                if (usuario == null)
                {
                    return NotFound(new { message = "Usuário não encontrado" });
            }

                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno no servidor", detalhe = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] Usuario usuarioAtualizado)
        {
            var resultado = await _userService.UpdateProfileAsync(id, usuarioAtualizado);  // Alteração aqui
            return resultado == "Perfil atualizado com sucesso!" ? Ok(resultado) : NotFound(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var resultado = await _userService.DeleteUserAsync(id);  // Alteração aqui
            return resultado == "Usuário excluído com sucesso!" ? Ok(resultado) : NotFound(resultado);
        }
    }
}
