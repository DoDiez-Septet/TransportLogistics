namespace TransportLogistics.Domain.Interfaces.Services;

public interface IRabbitMqService
{
    public Task<bool> Connect();

    public Task<bool> Disconnect();

    public void DeclareQueue();

    public Task StartWaitingForMessages();
}