using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(Usuario usuario);
        Task<bool> Login(LoginRequest loginRequest);
    }
}
