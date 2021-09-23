using final_assignment.Common.Models;
using System.Collections.Generic;
namespace final_assignment.DAL.Data.Repositories.NonFood
{
    public interface INonFoodRepository
    {
        IEnumerable<NonFoodModel> GetAllNonFood();
        NonFoodModel GetNonFoodModelId(int id);
        NonFoodModel AddNonFood(NonFoodModel nonFood);
        NonFoodModel UpdateNonFoodById(NonFoodModel nonFood);
    }
}
