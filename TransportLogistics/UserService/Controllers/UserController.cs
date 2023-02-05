using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Domain.Interfaces.Users.Services;
using TransportLogistics.Domain.Models.Users;

namespace UserService.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : Controller
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices) 
    { 
        _userServices = userServices;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<User>> GetAllUsers()
    {
        var users = _userServices.GetAll().ToArray();

        if (!users.Any())
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpGet("{Id}")]
    public ActionResult<User> GetUser(string Id)
    {
        return _userServices.GetById(Id) switch
        {
            null => NotFound(),
            var user => user
        };
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        var newUserId = _userServices.New(user);
        return Ok($"api/users/{newUserId}");
    }

    [HttpPut("{Id}")]
    public ActionResult<string> UpdateUser(string Id, User user)
    {
        var newUserId = _userServices.Edit(Id, user);
        return Ok($"api/users/{newUserId}");
    }

    [HttpDelete("{Id}")]
    public ActionResult DeleteUser(string Id)
    {
        _userServices.Delete(Id);
        return Ok();
    }
}