using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Produto> GetAll();
    }
}
