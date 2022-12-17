global using OrderService.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OrderService.DataAccess;


namespace OrderService.BusinessLogic
{
    public static  class Bootstrapper
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            return
            services
            .AddDataAccess();
        }
        
    }
}
