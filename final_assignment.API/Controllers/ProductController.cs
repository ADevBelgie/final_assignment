using final_assignment.BLL.Services.Product;
using final_assignment.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        // GET api/Product?search=pizza
        [HttpGet]
        public List<ProductModel> Get(string search = "")
        {
            if (search == "")
            {
                return _productService.GetListAllProducts();
            }


            return _productService.GetListAllProducts() 
               .Where(x => x.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 // Not Case sensitive
                        || x.ProductType.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                        || x.Description.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) // Not Case sensitive
               .ToList();
        }
        // GET api/Product/id
        [HttpGet("{id}")]
        public ProductModel GetProduct(int id)
        {
            return _productService.GetProductById(id);
        }
        // GET api/Product/pageProduct/{amountPerPage}/{pageNumber}
        [HttpGet("pageProduct/{amountPerPage}/{pageNumber}")]
        public List<ProductModel> GetPageProduct(int amountPerPage, int pageNumber, string category = "none", bool obsolete = false)
        {
            return _productService.GetPageProducts(pageNumber, amountPerPage, category, obsolete);
        }
        // GET api/Product/pageProduct/{amountPerPage}/{pageNumber}
        [HttpGet("TotalpageProduct/{amountPerPage}")]
        public int GetTotalPageProduct(int amountPerPage, string category = "none", bool obsolete = false)
        {
            return _productService.GetTotalPageProduct(amountPerPage, category, obsolete);
        }
    }
}
