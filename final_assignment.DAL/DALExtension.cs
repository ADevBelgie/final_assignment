using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using final_assignment.DAL.Data.Repositories.Food;
using final_assignment.DAL.Data.Repositories.Login;
using final_assignment.DAL.Data.Repositories.NonFood;
using final_assignment.DAL.Data.Repositories.Product;
using final_assignment.DAL.Data.Repositories.ShoppingBag;
using final_assignment.DAL.Data.Repositories.ShoppingItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace final_assignment.DAL
{
    public static class DALExtension
    {
        public static IServiceCollection RegisterDAL(
            this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("Final_Assignment")));

            // add repos and their ınterface for higher level layers lıke so
            
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<INonFoodRepository, NonFoodRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IShoppingBagRepository, ShoppingBagRepository>();
            services.AddTransient<IShoppingItemRepository, ShoppingItemRepository>();

            return services;
        }
    }
}
