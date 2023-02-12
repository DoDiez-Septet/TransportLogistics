using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.DataAccess.Interfaces
{
    public interface IOrderDetailRepoEF : IRepository<OrderDetail>
    {
    }
}
