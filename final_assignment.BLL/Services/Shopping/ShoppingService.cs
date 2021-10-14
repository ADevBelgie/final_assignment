using final_assignment.Common.Models;
using final_assignment.DAL.Data.Repositories.ShoppingBag;
using final_assignment.DAL.Data.Repositories.ShoppingItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.BLL.Services.Shopping
{
    public class ShoppingService : IShoppingService
    {
        private readonly IShoppingBagRepository _shoppingBagRepository;
        private readonly IShoppingItemRepository _shoppingItemRepository;
        public ShoppingService(IShoppingBagRepository shoppingBagRepository, IShoppingItemRepository shoppingItemRepository)
        {
            _shoppingBagRepository = shoppingBagRepository;
            _shoppingItemRepository = shoppingItemRepository;
        }

        public ShoppingBagModel AddShoppingBag(ShoppingBagModel shoppingBagModel)
        {
            return _shoppingBagRepository.AddShoppingBag(shoppingBagModel);
        }

        public List<ShoppingItemModel> GetListAllShoppingItemWithShoppingBagId(int id)
        {
            return _shoppingItemRepository.GetAllShoppingItem().Where(si => si.ShoppingBagId == id).ToList();
        }

        public ShoppingBagModel GetShoppingBagById(int id)
        {
            return _shoppingBagRepository.GetShoppingBagById(id);
        }

        public ShoppingBagModel GetShoppingBagByLoginId(string id)
        {
            return _shoppingBagRepository.GetShoppingBagByLoginId(id);
        }
    }
}
