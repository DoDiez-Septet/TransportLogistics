using Microsoft.Extensions.DependencyInjection;
using OrderService.DataAccess.API;
using OrderService.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            return
            services.AddDbContextFactory<AppFactory>()
            .AddScoped(typeof(IRepository<>), typeof(RepoEF<>))
            .AddScoped<IUserRepoEF, UserRepoEF>()
            .AddScoped<ExecuteAPI>();

        }
    }
}
