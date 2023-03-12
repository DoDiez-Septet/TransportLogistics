global using OrderService.DataAccess.Interfaces;
global using OrderService.DataAccess.Repository;

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
            .AddDataAccess()
            .AddScoped<IPointOper, PointOper>()
            .AddScoped<IOrderDetailOper, OrderDetailOper>()
            .AddScoped<IOrderOper, OrderOper>()
            ;
        }
        
    }
}
