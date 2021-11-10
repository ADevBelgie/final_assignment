using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace final_assignment.DAL.Data.Repositories.ShoppingItem
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly AppDbContext _context;

        public ShoppingItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public ShoppingItemModel AddShoppingItem(ShoppingItemModel shoppingItem)
        {
            try
            {
                _context.ShoppingItems.Add(shoppingItem);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetShoppingItemId(shoppingItem.ShoppingBagId);
        }

        public IEnumerable<ShoppingItemModel> GetAllShoppingItem()
        {
            return _context.ShoppingItems;
        }

        public ShoppingItemModel GetShoppingItemId(int id)
        {
            return _context.ShoppingItems.FirstOrDefault(si => si.ID == id);
        }

        public ShoppingItemModel UpdateShoppingItemById(ShoppingItemModel shoppingItem)
        {
            try
            {
                _context.ShoppingItems.Update(shoppingItem);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetShoppingItemId(shoppingItem.ShoppingBagId);
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
