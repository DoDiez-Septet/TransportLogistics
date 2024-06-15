using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using TransportLogistics.Domain.Interfaces.Services;
using TransportLogistics.Domain.Interfaces.Users.Repository;
using System.Text;
using System.Text.Json;
using TransportLogistics.Domain.Models.Messages;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace CustomServices.IntegratedServices;

internal class RabbitMqService : IRabbitMqService
{
    private readonly string QueueName = string.Empty;

    IConfiguration _config;

    IUserRepository _userRepository;
    IServiceScopeFactory _scopeFactory;

    ConnectionFactory _factory;
    IConnection _connection;
    IModel _channel;
    EventingBasicConsumer _consumer;

    public RabbitMqService(IConfiguration config, IServiceScopeFactory scopeFactory)
    {
        _factory = new ConnectionFactory();
        _config = config;

        _scopeFactory = scopeFactory;

        QueueName = _config!.GetSection("RabbitMq:QueueName").Value;
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
        _channel.QueueDeclare(queue: QueueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
        _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        _consumer = new EventingBasicConsumer(_channel);
        _channel.BasicConsume(queue: QueueName,
                             autoAck: false,
                             consumer: _consumer);
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
            string response = string.Empty;

            var body = ea.Body.ToArray();
            var props = ea.BasicProperties;
            var replyProps = _channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;

            try
            {
                var message = Encoding.UTF8.GetString(body);

                //Debug.WriteLine(JsonSerializer.Serialize(new Message { Header = "user_service", Payload = "" }));

                var messageRequest = JsonSerializer.Deserialize<Message>(message);

                if (messageRequest!.Header == "user_service")
                {
                    _userRepository = _scopeFactory.CreateScope().ServiceProvider.GetService<IUserRepository>();
                    var users = _userRepository.GetAll();

                    var usersJson = JsonSerializer.Serialize(users);

                    var messageResponce = new Message
                    {
                        Header = messageRequest!.Header,
                        Payload = usersJson
                    };

                    response = JsonSerializer.Serialize(messageResponce); // Из репозитрия
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: [.] {e.Message}");
                response = string.Empty;
            }
            finally
            {
                var responseBytes = Encoding.UTF8.GetBytes(response);
                _channel.BasicPublish(exchange: string.Empty,
                                     routingKey: props.ReplyTo,
                                     basicProperties: replyProps,
                                     body: responseBytes);
                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
        };

        //await Task.CompletedTask;
    }
}
