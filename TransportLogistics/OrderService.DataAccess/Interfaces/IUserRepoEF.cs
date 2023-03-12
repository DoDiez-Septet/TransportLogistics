using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Interfaces
{
    public interface IUserRepoEF : IRepository<User>
    {
        public string UserApi { get; }
    }
}
