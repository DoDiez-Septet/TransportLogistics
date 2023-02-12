using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Repository
{
    public class UserRepoEF : RepoEF<User>, IUserRepoEF
    {
        public UserRepoEF(AppFactory appFactory) : base(appFactory)
        {}

        public override Task<bool> Update(User entity)
        {
            User? osUser = _appFactory?.user.FirstOrDefault(x => x.Id == entity.Id);
            if (osUser != null)
            {
                osUser.FirstName = entity.FirstName;
                osUser.LastName = entity.LastName;
                osUser.Email = entity.Email;
                _appFactory?.SaveChanges();
                
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

    }
}
