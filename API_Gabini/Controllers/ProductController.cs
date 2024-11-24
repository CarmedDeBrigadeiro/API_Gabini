using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gabini.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllProducts()
        {
            var produtos = await _productService.GetAllProdutosAsync();

            if (produtos == null || !produtos.Any())
            {
                return NotFound("Nenhum produto encontrado.");
            }

            return Ok(produtos);
        }
    }
}
