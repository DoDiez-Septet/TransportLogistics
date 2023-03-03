using TransportLogistics.Domain.Interfaces.Common;
using TransportLogistics.Domain.Models.Users;

namespace TransportLogistics.Domain.Interfaces.Users.Repository;

public interface IUserRepository : ICrudRepository<User>
{
}