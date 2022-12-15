using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        private readonly ExecuteAPI _Context;

        public TestController(ExecuteAPI executeAPI)
        {
            _Context = executeAPI;
        }


        [HttpPost]
        [Route("/test/insertUser")]
        public Task CreateTestUser()
        {
            _Context.CreateUser();
            return Task.CompletedTask;
            
        }

        
    }
}
