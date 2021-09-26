using final_assignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.BLL.Services.Product
{
    public interface IProductService
    {
        List<ProductModel> GetPageProducts(int amountPerPage, int pageNumber, string catergory = "none", bool obsolete = false);
        int GetTotalPageProduct(int amountPerPage, string catergory = "none", bool obsolete = false);
        List<ProductModel> GetListAllProducts();
        List<ProductModel> GetListProductsCategory(string catergory);
        FoodModel GetFoodProductById(int id);
        NonFoodModel GetNonFoodProductById(int id);
        public ProductModel GetProductById(int id);
    }
}
