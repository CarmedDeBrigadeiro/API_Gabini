using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext context) => _context = context;

        public IEnumerable<Produto> GetAll() => _context.Produtos.ToList();
    }
}
