using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Produto> GetAllProdutos();
    }
}
