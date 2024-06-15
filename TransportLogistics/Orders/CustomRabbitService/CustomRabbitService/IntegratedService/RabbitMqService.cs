using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using TransportLogistics.Domain.Interfaces.Services;
using TransportLogistics.Domain.Models.Messages;

namespace CustomRabbitService.IntegratedService;

internal class RabbitMqService : IRabbitMqClient
{
    private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> callbackMapper = new();

    private string replyQueueName = string.Empty;

    IConfiguration _config;

    ConnectionFactory _factory;
    IConnection _connection;
    IModel _channel;
    EventingBasicConsumer _consumer;

    public RabbitMqService(IConfiguration config)
    {
        _config = config;

        _factory = new ConnectionFactory();
    }

    public Task<string> CallAsync(Message message, CancellationToken cancellationToken = default)
    {
        var payLoad = JsonSerializer.Serialize(message);
        IBasicProperties props = _channel.CreateBasicProperties();
        var correlationId = Guid.NewGuid().ToString();
        props.CorrelationId = correlationId;
        props.ReplyTo = replyQueueName;
        var messageBytes = Encoding.UTF8.GetBytes(payLoad);
        var tcs = new TaskCompletionSource<string>();
        callbackMapper.TryAdd(correlationId, tcs);

        _channel.BasicPublish(exchange: string.Empty,
                             routingKey: message.Header,
                             basicProperties: props,
                             body: messageBytes);

        cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));
        return tcs.Task;
    }

    public Task<bool> Connect()
    {
        _factory.UserName = _config.GetSection("RabbitMq:UserName").Value;//"wlgaomgd";
        _factory.Password = _config.GetSection("RabbitMq:Password").Value; //"w6BBVJx1f6Lav44-bxCTAC33FS6NV5w1";
        _factory.VirtualHost = _config.GetSection("RabbitMq:VirtualHost").Value; //"wlgaomgd";
        _factory.Port = Convert.ToInt32(_config.GetSection("RabbitMq:Port").Value); //5672;
        _factory.Uri = new Uri(_config!.GetSection("RabbitMq:Uri").Value);//"amqps://wlgaomgd:w6BBVJx1f6Lav44-bxCTAC33FS6NV5w1@sparrow.rmq.cloudamqp.com/wlgaomgd");

        _connection = _factory.CreateConnection();

        _channel = _connection.CreateModel();

        if (_channel is not null)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public void DeclareQueue()
    {
        replyQueueName = _channel.QueueDeclare().QueueName;
        _consumer = new EventingBasicConsumer(_channel);
    }

    public Task<bool> Disconnect()
    {
        _channel.Close();
        _connection.Close();

        return Task.FromResult(true);
    }

    public async Task StartWaitingForMessages()
    {
        _consumer.Received += (model, ea) =>
        {
            if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                return;
            var body = ea.Body.ToArray();
            var response = Encoding.UTF8.GetString(body);
            tcs.TrySetResult(response);
        };

        _channel.BasicConsume(consumer: _consumer,
                             queue: replyQueueName,
                             autoAck: true);
    }
}