using CustomServices.IntegratedServices;
using Microsoft.Extensions.DependencyInjection;
using TransportLogistics.Domain.Interfaces.Services;

namespace CustomServices;

public static class CustomServicesInjector
{
    public static IServiceCollection AddCustomIntegratedServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<IRabbitMqService, RabbitMqService>() 
            .AddHostedService<RabbitMqHostedService>();
    }
}