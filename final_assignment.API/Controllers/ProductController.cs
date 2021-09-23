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
    public class ProductController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        public List<ProductModel> Get()
        {
            return _productService.GetListAllProducts();
        }
        // GET api/Product/food
        [HttpGet("food")]
        public List<FoodModel> GetFoodProduct()
        {
            return _productService.GetListProductsCategory("food")
                .ToList()
                .Cast<FoodModel>()
                .ToList(); 
        }
        // GET api/Product/food/id
        [HttpGet("food/{id}")]
        public FoodModel GetFoodProductById(string id)
        {
            if (int.TryParse(id, out int realId))
            {
                return _productService.GetFoodProductById(realId);
            }
            return null;
        }
        // GET api/Product/nonfood
        [HttpGet("nonfood")]
        public List<NonFoodModel> GetNonFoodProduct()
        {
            return _productService.GetListProductsCategory("nonFood")
                .ToList()
                .Cast<NonFoodModel>()
                .ToList();
        }
        // GET api/Product/food/id
        [HttpGet("nonFood/{id}")]
        public NonFoodModel GetNonFoodProductById(string id)
        {
            if (int.TryParse(id, out int realId))
            {
                return _productService.GetNonFoodProductById(realId);
            }
            return null;
        }
    }
}
