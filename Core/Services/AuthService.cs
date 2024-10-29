using Core.Entities;
using Infrastructure.Data;
using System;
using System.Linq;

namespace Core.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public string Register(Usuario usuario)
        {
            var usuarioExistente = _context.Usuarios.Any(u => u.Username == usuario.Username);
            if (usuarioExistente)
                return "Usuário já registrado!";

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return "Usuário registrado com sucesso!";
        }

        public string Login(Usuario login)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            if (usuario == null)
                return "Usuário ou senha inválidos!";

            return "Login realizado com sucesso!";
        }
    }
}
