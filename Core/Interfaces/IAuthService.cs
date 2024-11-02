using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(Usuario usuario);
        Task<string> Login(LoginRequest loginRequest);
    }
}
