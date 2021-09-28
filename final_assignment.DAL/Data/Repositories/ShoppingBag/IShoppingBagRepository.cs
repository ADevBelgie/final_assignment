using final_assignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.ShoppingBag
{
    public interface IShoppingBagRepository
    {
        IEnumerable<ShoppingBagModel> GetAllShoppingBag();
        ShoppingBagModel GetShoppingBagById(int id);
        ShoppingBagModel GetShoppingBagByLoginId(string id);
        ShoppingBagModel AddShoppingBag(ShoppingBagModel shoppingBag);
        ShoppingBagModel UpdateShoppingBagById(ShoppingBagModel shoppingBag);
    }
}
