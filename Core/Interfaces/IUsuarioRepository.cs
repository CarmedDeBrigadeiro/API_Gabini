using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {
        void AdicionarUsuario(Usuario usuario);
        Usuario ObterUsuario(string username);
    }
}

