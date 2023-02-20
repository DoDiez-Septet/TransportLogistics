using CustomerService.DataAccess.Deprecated;
using CustomerService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Interfaces.Customers.Repository;
using TransportLogistics.Domain.Models.Customers;

namespace CustomerService.DataAccess.Repos
{
    public class CustomerRepo : ICustomerRepository //Repository<CustomerDb, Guid>
    {
        protected readonly DbContext Context;
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        CustomerRepo(DbContext dbContext)
        {
            Context = dbContext;
            //EntitySet = Context.Set<T>();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(string Id, Customer entry)
        {
            throw new NotImplementedException();
        }

        public Customer? Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public string New(Customer entry)
        {
            throw new NotImplementedException();
        }
    }
}
