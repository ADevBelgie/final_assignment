using final_assignment.Common.Models;
using System.Collections.Generic;

namespace final_assignment.DAL.Data.Repositories.ProductSale
{
    public interface IProductSaleRepository
    {
        IEnumerable<ProductModel> GetAllProduct();
    }
}
