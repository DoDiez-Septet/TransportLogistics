using TransportLogistics.Domain.Models.Order;

namespace OrderService.DataAccess.Interfaces
{
    public interface IOrderRepoEF 
    {
        public Task<List<Orders>> Get();
        public Task<Orders> Get(Guid id);
        public Task<Guid> Add(Orders entity);
        public Task<bool> Update(Orders entity);
        public Task<bool> Delete(Guid Id);

    }
}
