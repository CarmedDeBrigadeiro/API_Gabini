using Core.DTOs;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<UsuarioDTO> GetUserByIdAsync(int id);
        Task<string> UpdateProfileAsync(int id, Usuario usuario);
        Task<string> DeleteUserAsync(int id);
    }

}
