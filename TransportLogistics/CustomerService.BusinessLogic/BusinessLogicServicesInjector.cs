using Microsoft.Extensions.DependencyInjection;
using TransportLogistics.Domain.Interfaces.Customers.Services;
using CustomerService.BusinessLogic.BusinesServices;

namespace CustomerService.BusinessLogic;

public static class BusinessLogicServicesInjector
{
    public static IServiceCollection AddCustomersBusinessLogic(this IServiceCollection services)
    {
        return services
            .AddScoped<ICustomerServices, CustomerServices>();
    }
}