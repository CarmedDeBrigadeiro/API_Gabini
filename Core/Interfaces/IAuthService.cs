using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ports.Services
{
    public interface IAuthService
    {
        string Register(Usuario usuario);
        string Login(Usuario login);
    }
}


