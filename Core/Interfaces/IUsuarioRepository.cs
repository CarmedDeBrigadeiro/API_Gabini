using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioAsync(string id);  // Usando string
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task RemoverUsuarioAsync(Usuario usuario);
    }
}
