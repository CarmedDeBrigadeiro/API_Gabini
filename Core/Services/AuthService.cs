using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AuthService : IAuthService
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public async Task<string> Register(Usuario usuario)
        {
            return await Task.Run(() =>
            {
                var usuarioExistente = usuarios.Any(u => u.ID_Usuario == usuario.ID_Usuario);
                if (usuarioExistente)
                    return "Usuário já registrado!";

                usuarios.Add(usuario);
                return "Usuário registrado com sucesso!";
            });
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            return await Task.Run(() =>
            {
                var usuario = usuarios.FirstOrDefault(u => u.Email == loginRequest.Email && u.SenhaHash == loginRequest.SenhaHash);
                if (usuario == null)
                    return "Usuário ou senha inválidos!";

                return "Login realizado com sucesso!";
            });
        }
    }
}
