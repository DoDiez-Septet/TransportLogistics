using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TransportLogistics.Domain.Interfaces.Customers.Repository;
using CustomerService.DataAccess.Repos;
using Microsoft.Extensions.Configuration;

namespace CustomerService.DataAccess;

public static class DataAccessServiceInjector
{
    public static IServiceCollection AddCustomersDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddAutoMapper(typeof(MapperProfile))
            .AddDbContext<ApplicationDbContext>(options => 
                          options.UseSqlServer(configuration.GetConnectionString("DbConnection")))
            .AddScoped<ICustomerRepository, CustomerRepo>();
    }
}