using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.BusinessLogic.Services
{
    public interface IOrderDetailOper
    {
        public Task<List<OrderDetail>> Get();
        public Task<OrderDetail> Get(string guid);
        public Task Add(OrderDetail orderDetail);
        public Task<bool> Update(OrderDetail orderDetail);
        public Task<bool> Delete(string guid);
    }
}
