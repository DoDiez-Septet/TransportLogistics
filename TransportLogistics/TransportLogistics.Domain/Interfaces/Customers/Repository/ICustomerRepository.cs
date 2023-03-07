using TransportLogistics.Domain.Interfaces.Common;
using TransportLogistics.Domain.Models.Customers;

namespace TransportLogistics.Domain.Interfaces.Customers.Repository;

public interface ICustomerRepository : ICrudRepository<Customer>
{
}