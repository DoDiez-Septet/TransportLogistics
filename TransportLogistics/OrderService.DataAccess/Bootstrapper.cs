global using OrderService.DataAccess.Interfaces;
global using OrderService.DataAccess.Repository;
global using OrderService.DataAccess.Models;
using Microsoft.Extensions.DependencyInjection;


namespace OrderService.DataAccess
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            return
            services
            .AddDbContextFactory<AppFactory>()
            .AddScoped(typeof(IRepository<>), typeof(RepoEF<>))
            .AddScoped<IUserRepoEF, UserRepoEF>()
            ;
        }
    }
}
