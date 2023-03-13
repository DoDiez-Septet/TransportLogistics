using TransportLogistics.Domain.Models.Customers;

namespace OrderService.DataAccess.Interfaces
{
    public interface ICustomerRepoEF
    {
        public Task<bool> Update(Customer entity);
        public Task<List<Customer>> Get();
        public Task<Customer?> Get(Guid guid);
    }
}
