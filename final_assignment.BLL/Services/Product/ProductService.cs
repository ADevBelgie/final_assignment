using final_assignment.Common.Models;
using final_assignment.DAL.Data.Repositories.Food;
using final_assignment.DAL.Data.Repositories.NonFood;
using final_assignment.DAL.Data.Repositories.Product;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.BLL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly INonFoodRepository _nonFoodRepository;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IFoodRepository FoodRepository,
            INonFoodRepository NonFoodRepository,
            IProductRepository ProductSaleRepository)
        {
            _foodRepository = FoodRepository;
            _nonFoodRepository = NonFoodRepository;
            _productRepository = ProductSaleRepository;
        }
        public List<ProductModel> GetPageProducts(int pageNumber = 1, int amountPerPage = 9, string catergory = "none", bool obsolete = false)
        {
            // Get all products of the selected category
            var productList = GetListProductsCategory(catergory);
            if (productList != null)
            {
                // Filter all obsolete products if not turned off
                if (!obsolete)
                {
                    productList.RemoveAll(x => x.Obsolete == true);
                }
                // Get products for 1 page
                var onePageProducts = productList
                    .OrderBy(i => i.ProductId) // Could implement order by price
                    .Skip((pageNumber - 1) * amountPerPage)
                    .Take(amountPerPage)
                    .ToList();

                return onePageProducts;
            }
            return null;
        }
        public int GetTotalPageProduct(int amountPerPage, string catergory = "none", bool obsolete = false)
        {
            // Get all products of the selected category
            var productList = GetListProductsCategory(catergory);
            if (productList != null)
            {
                // Filter all obsolete products if not turned off
                if (!obsolete)
                {
                    productList.RemoveAll(x => x.Obsolete == true);
                }

                // Calculate amount of pages
                return (productList.Count() + (amountPerPage - 1))/amountPerPage;
            }
            return 0;
        }
        public List<ProductModel> GetListAllProducts()
        {
            return _productRepository.GetAllProduct().ToList();
        }
        public List<ProductModel> GetListProductsCategory(string catergory)
        {
            switch (catergory)
            {
                case "food":
                    return _foodRepository.GetAllFood()
                        .ToList()
                        .Cast<ProductModel>()
                        .ToList();
                case "nonfood": 
                    return _nonFoodRepository.GetAllNonFood()
                        .ToList()
                        .Cast<ProductModel>()
                        .ToList();
                case "none":
                    return _productRepository.GetAllProduct()
                        .ToList();
                default:
                    // Logging
                    return null;

            }
        }

        public FoodModel GetFoodProductById(int id)
        {
            return _foodRepository.GetFoodModelId(id);
        }
        public NonFoodModel GetNonFoodProductById(int id)
        {
            return _nonFoodRepository.GetNonFoodModelId(id);
        }
        public ProductModel GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

    }
}
