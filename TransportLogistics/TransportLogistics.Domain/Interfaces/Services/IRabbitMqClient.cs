using TransportLogistics.Domain.Models.Messages;

namespace TransportLogistics.Domain.Interfaces.Services;

public interface IRabbitMqClient : IRabbitMqService
{
    public Task<string> CallAsync(Message message, CancellationToken cancellationToken = default);
}