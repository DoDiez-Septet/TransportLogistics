using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.Controllers
{
    [Route("api/orderservice/orderdetail")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailOper _repo;

        public OrderDetailController(IOrderDetailOper repo)
        {
            _repo = repo;
        }

        [HttpGet("get")]
        public async Task<List<OrderDetail>> Get()
        {
            return await _repo.Get();
        }

        [HttpGet("get/{id}")]
        public async Task<OrderDetail> Get(string id)
        {
            return await _repo.Get(id);
        }

        [HttpGet("getbyOrderId/{orderId}")]
        public async Task<List<OrderDetail>> GetByOrderId(string orderId)
        {
            return await _repo.GetOrderDetailsByOrderId(orderId);
        }

        [HttpPut("add")]
        public async Task Add(OrderDetail orderDetail)
        {
            await _repo.Add(orderDetail);
        }

        [HttpPost("update")]
        public async Task<bool> Update(OrderDetail orderDetail)
        {
            return await _repo.Update(orderDetail);
        }

        [HttpDelete("delete")]
        public async Task Delete(string Id)
        {
            await _repo.Delete(Id);
        }
    }
}
