using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> GetUserByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(id.ToString());

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado!");
            }

            return new UsuarioDTO(
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
        }

        public async Task<string> UpdateProfileAsync(int id, Usuario usuarioAtualizado)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(id.ToString());
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

            await _usuarioRepository.AdicionarUsuarioAsync(usuario); // Atualizando o banco

            return "Perfil atualizado com sucesso!";
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(id.ToString());
            if (usuario == null)
                return "Usuário não encontrado!";

            await _usuarioRepository.RemoverUsuarioAsync(usuario); 
            return "Usuário excluído com sucesso!";
        }
    }
}
