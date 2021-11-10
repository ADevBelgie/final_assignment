using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace final_assignment.DAL.Data.Repositories.ShoppingBag
{
    public class ShoppingBagRepository : IShoppingBagRepository
    {
        private readonly AppDbContext _context;

        public ShoppingBagRepository(AppDbContext context)
        {
            _context = context;
        }
        public ShoppingBagModel AddShoppingBag(ShoppingBagModel shoppingBag)
        {
            try
            {
                _context.ShoppingBags.Add(shoppingBag);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetShoppingBagById(shoppingBag.ShoppingBagId);
        }

        public IEnumerable<ShoppingBagModel> GetAllShoppingBag()
        {
            
            return _context.ShoppingBags;
        }

        public ShoppingBagModel GetShoppingBagById(int id)
        {
            return _context.ShoppingBags.Include("Items").FirstOrDefault(sb => sb.ShoppingBagId == id);
        }

        public ShoppingBagModel GetShoppingBagByLoginId(string id)
        {
            return _context.ShoppingBags.Include("Items").FirstOrDefault(sb => sb.LoginId == id);
        }

        public ShoppingBagModel UpdateShoppingBagById(ShoppingBagModel shoppingBag)
        {
            try
            {
                _context.ShoppingBags.Update(shoppingBag);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetShoppingBagById(shoppingBag.ShoppingBagId);
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
