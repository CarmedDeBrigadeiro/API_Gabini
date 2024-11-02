using Ports.Services;
using Core.Entities; 

namespace Ports.Services
{
    public interface IAuthService
    {
        string Register(Usuario usuario);
        string Login(LoginRequest loginRequest);
    }
}
