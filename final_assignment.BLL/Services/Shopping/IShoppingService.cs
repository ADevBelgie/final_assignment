using final_assignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.BLL.Services.Shopping
{
    public interface IShoppingService
    {
        ShoppingBagModel GetShoppingBagById(int id);
        List<ShoppingItemModel> GetListAllShoppingItemWithShoppingBagId(int id);
        ShoppingBagModel AddShoppingBag(ShoppingBagModel shoppingBagModel);
        ShoppingBagModel GetShoppingBagByLoginId(string id);
        ShoppingItemModel AddShoppingItem(ShoppingItemModel shoppingItem);
        ShoppingItemModel UpdateShoppingItemById(ShoppingItemModel shoppingItem);
        void DeleteShoppingItemByProductId(int productId);
    }
}
