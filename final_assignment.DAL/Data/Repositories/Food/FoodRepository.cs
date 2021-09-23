using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.Food
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;
        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public FoodModel AddFood(FoodModel food)
        {
            try
            {
                _context.FoodProducts.Add(food);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetFoodModelId(food.ProductId);
        }

        public IEnumerable<FoodModel> GetAllFood()
        {
            return _context.FoodProducts;
        }

        public FoodModel GetFoodModelId(int id)
        {
            return _context.FoodProducts.FirstOrDefault(x => x.ProductId == id);
        }

        public FoodModel UpdateFoodById(FoodModel food)
        {
            try
            {
                _context.FoodProducts.Update(food);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetFoodModelId(food.ProductId);
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
