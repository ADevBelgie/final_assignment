using final_assignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.ShoppingItem
{
    public interface IShoppingItemRepository
    {
        IEnumerable<ShoppingItemModel> GetAllShoppingItem();
        ShoppingItemModel GetShoppingItemId(int id);
        ShoppingItemModel AddShoppingItem(ShoppingItemModel shoppingItem);
        ShoppingItemModel UpdateShoppingItemById(ShoppingItemModel shoppingItem);
        void DeleteShoppingItemByProductId(int productId);
    }
}
