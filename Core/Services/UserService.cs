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
            var usuario = usuarios.FirstOrDefault(u => u.ID_Usuario == id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado!");
            }
            return usuario;
        }


        public string UpdateProfile(int id, Usuario usuarioAtualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.ID_Usuario == id);
            if (usuario == null)
                return "Usuário não encontrado!";

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Sobrenome = usuarioAtualizado.Sobrenome;
            usuario.Username = usuarioAtualizado.Username;
            usuario.Email = usuarioAtualizado.Email;
            usuario.SenhaHash = usuarioAtualizado.SenhaHash;
            usuario.Data_Registro = usuarioAtualizado.Data_Registro;
            usuario.Telefone = usuarioAtualizado.Telefone;
            usuario.Genero = usuarioAtualizado.Genero;
            usuario.CPF = usuarioAtualizado.CPF;
            usuario.FotoUrl = usuarioAtualizado.FotoUrl;

            usuario.Enderecos = usuarioAtualizado.Enderecos;

            return "Perfil atualizado com sucesso!";
        }

        public string DeleteUser(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.ID_Usuario == id);
            if (usuario == null)
                return "Usuário não encontrado!";

            usuarios.Remove(usuario);
            return "Usuário excluído com sucesso!";
        }
    }
}
