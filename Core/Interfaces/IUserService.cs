using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Usuario GetUserById(int id);

        string UpdateProfile(int id, Usuario usuario);

        string DeleteUser(int id);
    }
}
