using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        private readonly IRepository<OSUser> _userContext;
        private readonly IUserRepoEF _userRepo;

        public TestController(IRepository<OSUser> repository, IUserRepoEF userRepoEF)
        {
            _userContext = repository;
            _userRepo = userRepoEF;
        }


        [HttpPost]
        [Route("/test/insertUser")]
        public async Task CreateTestUser()
        {
            Guid userId = Guid.NewGuid();
            await _userContext.Add(new OSUser
            {
                Id = userId,
                FirstName = "TestUser1",
                LastName = "Last1",
                Email = "email@com2"
            });
            
        }

        [HttpPost, Route("/test/Update")]
        public async Task UpdateTestUser()
        {
            OSUser user = new OSUser()
            {
                Id = new Guid("0ECB7035-E111-48CF-BC87-0D671DA76F67"),
                FirstName = "Новое имя 4",
                LastName = "Last1",
                Email = "email@com2"
            };
            _userRepo.Update(user);
        }
    }
}
