using Microsoft.AspNetCore.Mvc;
using OrderService.DataAccess.Interfaces;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepoEF _user;
        public UserController(IUserRepoEF user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<List<User>> Get() 
        {
            return await _user.Get();
        }
    }
}
