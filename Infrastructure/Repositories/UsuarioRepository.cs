//using Core.Entities;
//using Core.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Ports;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Infrastructure
//{
//    public class UsuarioRepository : IUsuarioRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public UsuarioRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
//        {
//            _context.Usuarios.Add(usuario);
//            await _context.SaveChangesAsync();
//            return usuario;
//        }

//        public async Task<Usuario> ObterUsuarioPorUsername(string username)
//        {
//            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
//        }

//        public async Task<List<Usuario>> ListarUsuarios()
//        {
//            return await _context.Usuarios.Include(u => u.Enderecos).ToListAsync();
//        }
//    }
//}
