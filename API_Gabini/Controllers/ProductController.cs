using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Produto>> GetAllProducts()
        {
            var produtos = _productService.GetAllProdutos();

            if (produtos == null)
            {
                return NotFound("Nenhum produto encontrado.");
            }

            return Ok(produtos);
        }
    }
}
