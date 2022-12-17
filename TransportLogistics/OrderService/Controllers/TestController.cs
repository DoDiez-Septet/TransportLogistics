using Microsoft.AspNetCore.Mvc;
using OrderService.DataAccess.Interfaces;

namespace OrderService.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        private readonly IUserRepoEF _Context;

        public TestController(IUserRepoEF userRepoEF)
        {
            _Context = userRepoEF;
        }


        [HttpPost]
        [Route("/test/insertUser")]
        public async Task<Guid> CreateTestUser()
        {
            Guid id = await _Context.Add(new DataAccess.Models.OSUser()
            {
                FirstName = "InitFirstName",
                LastName = DateTime.Now.ToString("hh.mm.ss")
            });

            return id;
        }
        
    }
}
