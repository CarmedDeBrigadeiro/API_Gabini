using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetUserById(int id)
        {
            try
            {
                var usuario = _userService.GetUserById(id);

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
        public IActionResult UpdateProfile(int id, [FromBody] Usuario usuarioAtualizado)
        {
            var resultado = _userService.UpdateProfile(id, usuarioAtualizado);
            return resultado == "Perfil atualizado com sucesso!" ? Ok(resultado) : NotFound(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var resultado = _userService.DeleteUser(id);
            return resultado == "Usuário excluído com sucesso!" ? Ok(resultado) : NotFound(resultado);
        }
    }
}
    