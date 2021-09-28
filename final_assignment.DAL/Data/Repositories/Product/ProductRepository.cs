using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductModel> GetAllProduct()
        {
            IEnumerable<ProductModel> AllProducts = _context.Products;

            return AllProducts;
        }

        public ProductModel GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }
    }
}
