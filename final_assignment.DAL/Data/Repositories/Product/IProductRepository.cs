using final_assignment.Common.Models;
using System.Collections.Generic;

namespace final_assignment.DAL.Data.Repositories.Product
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProduct();
    }
}
