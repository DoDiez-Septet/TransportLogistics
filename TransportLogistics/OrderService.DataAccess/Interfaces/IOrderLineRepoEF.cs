using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Interfaces
{
    public interface IOrderLineRepoEF : IRepository<OrderLine>
    {
    }
}
