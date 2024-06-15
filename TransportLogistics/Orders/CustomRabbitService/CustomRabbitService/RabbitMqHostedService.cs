using Microsoft.Extensions.Hosting;
using TransportLogistics.Domain.Interfaces.Services;

namespace CustomRabbitService;

internal class RabbitMqHostedService : BackgroundService
{
    IRabbitMqService _rabbitMqService;

    public RabbitMqHostedService(IRabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
        _rabbitMqService.Connect();
        _rabbitMqService.DeclareQueue();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _rabbitMqService.StartWaitingForMessages();
    }

    public override void Dispose()
    {
        _rabbitMqService.Disconnect();
        base.Dispose();
    }
}