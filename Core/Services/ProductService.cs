using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            return _productRepository.GetAll();
        }
    }
}
