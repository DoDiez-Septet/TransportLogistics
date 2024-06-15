global using OrderService.DataAccess.Interfaces;
global using OrderService.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

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

            .AddScoped<IUserRepoEF, UserRepoRabbitMq>()//UserRepoEF>()

            .AddScoped<IPointRepoEF, PointRepoEF>()
            .AddScoped<IOrderDetailRepoEF, OrderDetailRepoEF>()
            .AddScoped<IOrderRepoEF, OrderRepoEF>()
            .AddScoped<ICustomerRepoEF, CustomersRepoEF>();
        }
    }
}
