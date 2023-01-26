global using OrderService.DataAccess.Interfaces;
global using OrderService.DataAccess.Repository;
global using OrderService.BusinessLogic.Models;
using Microsoft.Extensions.DependencyInjection;
using OrderService.DataAccess;
using OrderService.BusinessLogic.Services;

namespace OrderService.BusinessLogic
{
    public static  class Bootstrapper
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            return
            services
            .AddScoped<IPointOper, PointOper>()
            .AddDataAccess();
        }
        
    }
}
