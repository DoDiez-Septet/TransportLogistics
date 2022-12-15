using OrderService.DataAccess.Repository;

namespace OrderService.DataAccess.API
{
    public class ExecuteAPI
    {
        private readonly IUserRepoEF _userRepo;

        public ExecuteAPI(IUserRepoEF userRepo)
        {
            _userRepo = userRepo;
        }

        public void CreateUser()
        {
             _userRepo.Add(new OSUser
            {
                FirstName = "TestUser1",
                LastName = "Last1",
                Email = "email@com2"
            }).Wait();
        }
    }
}
