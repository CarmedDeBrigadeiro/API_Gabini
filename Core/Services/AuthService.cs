using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Register(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioAsync(usuario.Email);
            if (usuarioExistente != null)
                return false;

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
            return true;
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(loginRequest.Email);
            if (usuario == null || usuario.Senha != loginRequest.Senha)
                return false;

            return true;
        }
    }
}
