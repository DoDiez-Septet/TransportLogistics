using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Models
{
    public class UserRepoEF : RepoEF<OSUser>, IUserRepoEF
    {

        public UserRepoEF(AppFactory appFactory) : base(appFactory)
        {}

        public override Task<bool> Update(OSUser entity)
        {
            OSUser? osUser = _appFactory?.user.FirstOrDefault(x => x.Id == entity.Id);
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
