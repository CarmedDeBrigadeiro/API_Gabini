using Core.Entities;
using Ports.Services;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(Usuario usuario);
        Task<string> Login(LoginRequest loginRequest);
    }
}
