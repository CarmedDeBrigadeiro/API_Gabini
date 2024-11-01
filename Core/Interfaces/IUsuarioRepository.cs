using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario); 
        Task<Usuario> ObterUsuarioAsync(string username); 
    }
}