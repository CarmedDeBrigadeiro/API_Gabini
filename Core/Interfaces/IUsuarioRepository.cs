using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task<Usuario?> ObterUsuarioAsync(string username);
    }
}
