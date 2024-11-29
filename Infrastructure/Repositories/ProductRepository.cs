using API_Gabini.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            return await _context.Set<Produto>().ToListAsync();  
        }
    }
}
