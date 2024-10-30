using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public Usuario GetUserById(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public string UpdateProfile(int id, Usuario usuarioAtualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return "Usuário não encontrado!";

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Telefone = usuarioAtualizado.Telefone;

            return "Perfil atualizado com sucesso!";
        }

        public string ChangePassword(int id, string newPassword)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return "Usuário não encontrado!";

            usuario.SenhaHash = newPassword;
            return "Senha alterada com sucesso!";
        }

        public string DeleteUser(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return "Usuário não encontrado!";

            usuarios.Remove(usuario);
            return "Usuário excluído com sucesso!";
        }
    }
}
