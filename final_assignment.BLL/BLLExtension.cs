using Microsoft.Extensions.DependencyInjection;

using final_assignment.BLL.Services.Product;

namespace final_assignment.BLL
{
    public static class BLLExtension
    {
        public static IServiceCollection RegisterBLL(this IServiceCollection services)
        {
            // Add servıces and their ınterface for higher level layers lıke so
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
