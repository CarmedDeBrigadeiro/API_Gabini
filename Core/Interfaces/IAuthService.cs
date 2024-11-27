using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(Usuario usuario);
        Task<string> Login(LoginRequest loginRequest);  // Retorno do tipo string (token)
        string GetJwtKey();
        string GetJwtIssuer();
        string GetJwtAudience();
    }


}
