using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TransportLogistics.Domain.Interfaces.Users.Repository;
using UserService.DataAccess.Repository;
using Microsoft.Extensions.Configuration;

namespace UserService.DataAccess;

public static class DataAccessServiceInjector
{
    public static IServiceCollection AddUsersDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddAutoMapper(typeof(MapperProfile))
            .AddDbContext<ApplicationDbContext>(options => 
                          options.UseSqlServer(configuration.GetConnectionString("DbConnection")))
            .AddScoped<IUserRepository, UserRepository>();
    }
}