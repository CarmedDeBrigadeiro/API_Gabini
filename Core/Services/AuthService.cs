using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class AuthService
    {
        private static List<Usuario> usuarios = new List<Usuario>();
        public string Register(Usuario usuario)
        {
            var usuarioExistente = usuarios.Any(u => u.Username == usuario.Username);
            if (usuarioExistente)
                return "Usuário já registrado!";

            usuarios.Add(usuario);
            return "Usuário registrado com sucesso!";
        }

        public string Login(Usuario login)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (usuario == null)
                return "Usuário ou senha inválidos!";

            return "Login realizado com sucesso!";
        }
    }
}
