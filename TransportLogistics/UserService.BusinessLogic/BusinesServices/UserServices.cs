using TransportLogistics.Domain.Interfaces.Users.Repository;
using TransportLogistics.Domain.Interfaces.Users.Services;
using TransportLogistics.Domain.Models.Users;

namespace UserService.BusinessLogic.BusinesServices;

internal class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Delete(string Id)
    {
        _userRepository.Delete(Id);
    }

    public User Edit(string Id, User user)
    {
        _userRepository.Edit(Id, user);

        return GetById(user.Id.ToString());
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll().ToArray();
    }

    public User? GetById(string Id)
    {
        return _userRepository.Get(Id);
    }

    public string New(User user)
    {
        var newUserId = _userRepository.New(user);
        return newUserId;
    }
}
