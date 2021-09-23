using final_assignment.DAL.Data.DB;
using final_assignment.DAL.Data.Repositories.Login;
using final_assignment.DAL.Data.Repositories.ProductSale;
using final_assignment.DAL.Data.Repositories.NonFood;
using final_assignment.DAL.Data.Repositories.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace final_assignment.DAL
{
    public static class DALExtension
    {
        public static IServiceCollection RegisterDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("Final_Assignment")));

            // add repos and their ınterface for higher level layers lıke so
            services.AddTransient<IProductSaleRepository, ProductSaleRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<INonFoodRepository, NonFoodRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();

            return services;
        }
    }
}
