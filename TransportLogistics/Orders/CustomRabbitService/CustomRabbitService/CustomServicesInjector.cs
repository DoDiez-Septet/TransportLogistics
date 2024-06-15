using CustomRabbitService.IntegratedService;
using Microsoft.Extensions.DependencyInjection;
using TransportLogistics.Domain.Interfaces.Services;

namespace CustomRabbitService;

public static class CustomServicesInjector
{
    public static IServiceCollection AddCustomIntegratedServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<IRabbitMqService, RabbitMqService>()
            .AddHostedService<RabbitMqHostedService>();
    }
}