using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.ProductSale
{
    public class ProductSaleRepository : IProductSaleRepository
    {
        private readonly AppDbContext _context;
        public ProductSaleRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductModel> GetAllProduct()
        {
            // Adding foods and non foods into 1 IEnumerable
            // Also makes sure either are not null
            IEnumerable<ProductModel> AllProducts = ((IEnumerable<ProductModel>)_context.FoodProducts ?? Enumerable.Empty<FoodModel>())
                .Concat((IEnumerable<ProductModel>)_context.NonFoodProducts ?? Enumerable.Empty<NonFoodModel>()); 

            return AllProducts;
        }
    }
}
