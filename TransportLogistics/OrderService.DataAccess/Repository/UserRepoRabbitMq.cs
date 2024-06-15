using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TransportLogistics.Domain.Interfaces.Services;
using TransportLogistics.Domain.Interfaces.Users.Repository;
using TransportLogistics.Domain.Models.Messages;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Repository;

internal class UserRepoRabbitMq : RepoEF<User>, IUserRepoEF
{
    private readonly string userQueueName = string.Empty;
    private List<User> users = new();
    IServiceScopeFactory _scopeFactory;    

    public UserRepoRabbitMq(AppFactory appFactory, IConfiguration config, IServiceScopeFactory scopeFactory) : base(appFactory)
    {
        userQueueName = config["UsersQueueName"] ?? string.Empty;

        _scopeFactory = scopeFactory;
    }

    public override Task<bool> Update(User entity)
    {
        throw new NotImplementedException();
    }

    public override async Task<List<User>> Get()
    {
        var _rabbitMqClient = _scopeFactory.CreateScope().ServiceProvider.GetService<IRabbitMqClient>();

        var requestMessage = new Message
        {
            Header = userQueueName,
            Payload = ""
        };

        var responceMessage = await _rabbitMqClient.CallAsync(requestMessage);

        var message = JsonConvert.DeserializeObject<Message>(responceMessage);

        users = JsonConvert.DeserializeObject<List<User>>(message.Payload);

        return users;
    }

    public override async Task<User> Get(Guid guid)
    {
        users = await Get();
        return users.FirstOrDefault(x => x.Id == guid) ?? null;
    }

    public string UserApi => userQueueName;
}
