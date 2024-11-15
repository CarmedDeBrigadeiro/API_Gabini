using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioDTO GetUserById(int id)
        {
            var usuario = _usuarioRepository.ObterUsuarioAsync(id.ToString()).Result; 

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado!");
            }

            var usuarioDto = new UsuarioDTO(
                usuario.ID_Usuario,
                usuario.Nome,
                usuario.Email,
                usuario.Telefone,
                usuario.Sobrenome,
                usuario.Username,
                usuario.Data_Registro,
                usuario.Telefone,
                usuario.Genero,
                usuario.CPF,
                usuario.Enderecos);

            return usuarioDto;
        }

        public string UpdateProfile(int id, Usuario usuarioAtualizado)
        {
            var usuario = _usuarioRepository.ObterUsuarioAsync(id.ToString()).Result;
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

            _usuarioRepository.AdicionarUsuarioAsync(usuario); // Atualizando o banco

            return "Perfil atualizado com sucesso!";
        }

        public string DeleteUser(int id)
        {
            var usuario = _usuarioRepository.ObterUsuarioAsync(id.ToString()).Result;
            if (usuario == null)
                return "Usuário não encontrado!";

            _usuarioRepository.RemoverUsuarioAsync(usuario); // Excluindo o usuário no repositório
            return "Usuário excluído com sucesso!";
        }
    }
}
