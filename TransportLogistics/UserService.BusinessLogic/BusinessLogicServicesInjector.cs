using Microsoft.Extensions.DependencyInjection;
using TransportLogistics.Domain.Interfaces.Users.Services;
using UserService.BusinessLogic.BusinesServices;

namespace UserService.BusinessLogic;

public static class BusinessLogicServicesInjector
{
    public static IServiceCollection AddUsersBusinessLogic(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserServices, UserServices>();
    }
}