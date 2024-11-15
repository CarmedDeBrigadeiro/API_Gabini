using Core.Entities;
using Core.DTOs;
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

        public async Task<string> Register(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioAsync(usuario.Username);
            if (usuarioExistente != null)
                return "Usuário já registrado!";

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
            return "Usuário registrado com sucesso!";
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(loginRequest.Email);
            if (usuario == null || usuario.SenhaHash != loginRequest.SenhaHash)
                return "Usuário ou senha inválidos!";

            return "Login realizado com sucesso!";
        }
    }
}
