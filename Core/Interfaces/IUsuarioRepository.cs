using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task<Usuario?> ObterUsuarioAsync(string username);
        Task RemoverUsuarioAsync(Usuario usuario); 
    }
}
