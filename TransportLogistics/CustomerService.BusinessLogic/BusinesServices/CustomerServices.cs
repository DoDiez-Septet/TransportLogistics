using TransportLogistics.Domain.Interfaces.Customers.Repository;
using TransportLogistics.Domain.Interfaces.Customers.Services;
using TransportLogistics.Domain.Models.Customers;

namespace CustomerService.BusinessLogic.BusinesServices;

internal class CustomerServices : ICustomerServices
{
    private readonly ICustomerRepository _CustomerRepository;

    public CustomerServices(ICustomerRepository CustomerRepository)
    {
        _CustomerRepository = CustomerRepository;
    }

    public void Delete(string Id)
    {
        _CustomerRepository.Delete(Id);
    }

    public Customer Edit(Customer Customer)
    {
        File.AppendAllText(@"log.txt", Customer.Id.ToString());

        _CustomerRepository.Edit(Customer.Id.ToString(), Customer);

        return GetById(Customer.Id.ToString());
    }

    public IEnumerable<Customer> GetAll()
    {
        return _CustomerRepository.GetAll().ToArray();
    }

    public Customer? GetById(string Id)
    {
        return _CustomerRepository.Get(Id);
    }

    public string New(Customer Customer)
    {
        var newCustomerId = _CustomerRepository.New(Customer);
        return newCustomerId;
    }
}
