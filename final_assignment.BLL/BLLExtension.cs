using Microsoft.Extensions.DependencyInjection;

using final_assignment.BLL.Services.Product;
using final_assignment.DAL;
using Microsoft.Extensions.Configuration;


namespace final_assignment.BLL
{
    public static class BLLExtension
    {

        public static IConfiguration Configuration { get; }
        public static IServiceCollection RegisterBLL(this IServiceCollection services, IConfiguration configuration)
        {
            // Add servıces and their ınterface for higher level layers lıke so
            services.AddTransient<IProductService, ProductService>();
            services.RegisterDAL(configuration);
            return services;
        }
    }
}
