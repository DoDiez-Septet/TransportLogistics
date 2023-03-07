using AutoMapper;
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
    internal class CustomerRepo : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepo(ApplicationDbContext CustomerDbContext, IMapper mapper)
        {
            _context = CustomerDbContext;
            _mapper = mapper;
        }

        public void Delete(string CustomerId)
        {
            if (Guid.TryParse(CustomerId, out Guid Id))
            {
                var CustomerToDelete = _context.Customers.Find(Id);
                if (CustomerToDelete is not null)
                {
                    _context.Entry(CustomerToDelete).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
        }

        public void Edit(string CustomerId, Customer Customer)
        {
            if (Guid.TryParse(CustomerId, out Guid Id))
            {
                if (_context.Customers.Find(Id) is CustomerDb CustomerInDb)
                {
                    CustomerInDb.Name = Customer.Name;
                    CustomerInDb.ContactPerson = Customer.ContactPerson;
                    CustomerInDb.Email = Customer.Email;
                    CustomerInDb.PhoneNumber = Customer.PhoneNumber;
                    CustomerInDb.Address = Customer.Address;

                    _context.Entry(CustomerInDb).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

        public Customer? Get(string CustomerId)
        {
            if (Guid.TryParse(CustomerId, out Guid Id))
            {
                var CustomerDb = _context.Customers.FirstOrDefault(x => x.Id == Id);
                return _mapper.Map<Customer?>(CustomerDb);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var CustomersDb = _context.Customers.ToList();
            return _mapper.Map<IReadOnlyCollection<Customer>>(CustomersDb);
        }

        public string New(Customer Customer)
        {
            var CustomerDb = _mapper.Map<CustomerDb>(Customer);
            var result = _context.Customers.Add(CustomerDb);
            _context.SaveChanges();

            return result.Entity.Id.ToString();
        }
    }
}
