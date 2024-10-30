using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Usuario GetUserById(int id);
        string UpdateProfile(int id, Usuario usuario);
        string ChangePassword(int id, string newPassword);
        string DeleteUser(int id);
    }
}
