using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Interfaces.Common;
using TransportLogistics.Domain.Models.Customers;

namespace TransportLogistics.Domain.Interfaces.Customers.Services
{
    internal interface ICustomerService : ICrudServices<Customer>
    {
    }
}
