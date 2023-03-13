global using OrderService.DataAccess.Interfaces;
global using OrderService.DataAccess.Repository;
global using OrderService.DataAccess.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace OrderService.DataAccess
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            return
            services
            .AddAutoMapper(typeof(MapProfiler))
            .AddDbContextFactory<AppFactory>()
            .AddScoped(typeof(IRepository<>), typeof(RepoEF<>))
            .AddScoped<IUserRepoEF, UserRepoEF>()
            .AddScoped<IPointRepoEF, PointRepoEF>()
            .AddScoped<IOrderDetailRepoEF, OrderDetailRepoEF>()
            .AddScoped<IOrderRepoEF, OrderRepoEF>()
            .AddScoped<ICustomerRepoEF, CustomersRepoEF>()            
            ;
        }
    }
}
