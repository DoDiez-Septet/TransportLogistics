using TransportLogistics.Domain.Models.Order;

namespace OrderService.BusinessLogic.Services
{
    public interface IOrderOper
    {
        public Task<List<Orders>> Get();
        public Task<Orders> Get(string id);
        public Task Update(Orders orders);
        public Task Add(Orders orders);
        public Task Delete(string id);
    }
}
