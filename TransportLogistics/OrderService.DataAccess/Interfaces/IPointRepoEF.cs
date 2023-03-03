using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Models.Points;

namespace OrderService.DataAccess.Interfaces
{
    public interface IPointRepoEF : IRepository<Point>
    {
        public Task<bool> Delete(string pointName);
    }
}
