using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.NonFood
{
    public class NonFoodRepository : INonFoodRepository
    {
        private readonly AppDbContext _context;
        public NonFoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public NonFoodModel AddNonFood(NonFoodModel nonFood)
        {
            try
            {
                _context.NonFoodProducts.Add(nonFood);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetNonFoodModelId(nonFood.ProductId);
        }

        public IEnumerable<NonFoodModel> GetAllNonFood()
        {
            return _context.NonFoodProducts;
        }

        public NonFoodModel GetNonFoodModelId(int id)
        {
            return _context.NonFoodProducts.FirstOrDefault(x => x.ProductId == id);
        }

        public NonFoodModel UpdateNonFoodById(NonFoodModel nonFood)
        {
            try
            {
                _context.NonFoodProducts.Update(nonFood);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetNonFoodModelId(nonFood.ProductId);
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
