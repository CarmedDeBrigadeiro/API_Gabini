using System.Collections.Generic;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Produto> GetAllProdutos();
    }
}
