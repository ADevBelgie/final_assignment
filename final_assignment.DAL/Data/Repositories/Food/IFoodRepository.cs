
using System.Collections.Generic;
using final_assignment.Common.Models;


namespace final_assignment.DAL.Data.Repositories.Food
{
    public interface IFoodRepository
    {
        IEnumerable<FoodModel> GetAllFood();
        FoodModel GetFoodModelId(int id);
        FoodModel AddFood(FoodModel food);
        FoodModel UpdateFoodById(FoodModel food);
    }
}
