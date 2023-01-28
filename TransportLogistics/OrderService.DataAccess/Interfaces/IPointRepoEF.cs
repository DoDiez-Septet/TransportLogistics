using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Interfaces
{
    public interface IPointRepoEF : IRepository<Point>
    {
        public Task<bool> Delete(string pointName);
    }
}
