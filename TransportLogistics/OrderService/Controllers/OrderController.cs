using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.Controllers
{
    [Route("api/orders/")]
    public class OrderController : Controller
    {
        private readonly IOrderOper _repo;
        public OrderController(IOrderOper orderOper)
        {
            _repo = orderOper;
        }

        [HttpGet]
        public async Task<List<Orders>> Get()
        {
            return await _repo.Get();
        }

        [HttpGet("/{id}")]
        public async Task<Orders> Get(string id)
        {
            return await _repo.Get(id);
        }

        [HttpPut]
        public async Task Put(Orders orders)
        {
            await _repo.Add(orders);
        }

        [HttpPost]
        public async Task Update(Orders orders)
        {
            await _repo.Update(orders);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _repo.Delete(id);
        }

    }
}
