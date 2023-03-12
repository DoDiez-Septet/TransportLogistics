using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.BusinessLogic.Services
{
    public class OrderOper : IOrderOper
    {
        private readonly IOrderRepoEF _repo;

        public OrderOper(IOrderRepoEF repo)
        {
            _repo = repo;
        }

        public async Task<List<Orders>> Get()
        {
            return await _repo.Get();
        }

        public async Task<Orders> Get(string id)
        {
            return await _repo.Get(Guid.Parse(id));   
        }

        public async Task Update(Orders orders)
        {
            if (orders.CustomerId == null)
            {
                orders.CustomerId = Guid.NewGuid();
            }
            if (orders.UserId == null)
            {
                orders.UserId = Guid.NewGuid();
            }
            await _repo.Update(orders);
        }

        public async Task Add(Orders orders)
        {
            await _repo.Add(orders);
        }

        public async Task Delete(string id)
        {
            await _repo.Delete(Guid.Parse(id));
        }
    }
}
