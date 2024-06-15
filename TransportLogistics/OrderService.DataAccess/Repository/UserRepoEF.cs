using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Repository
{
    public class UserRepoEF : RepoEF<User>, IUserRepoEF
    {
        private readonly string userApi = string.Empty;
        private List<User> users = new List<User>();
        public UserRepoEF(AppFactory appFactory, IConfiguration config) : base(appFactory)
        {
            userApi = config["UsersAPI"] ?? string.Empty;
        }

        public override Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<User>> Get()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List<User>>(userApi);
        }

        public override async Task<User> Get(Guid guid)
        {
            users = await Get();
            return users.FirstOrDefault(x => x.Id == guid) ?? null;
        }

        public string UserApi => userApi;

    }
}
