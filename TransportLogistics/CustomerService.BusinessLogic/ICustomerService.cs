using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.BusinessLogic
{
    internal interface ICustomerService
    {
        Guid Create(CustomerDto customerDto);
        CustomerDto GetById(Guid id);
        ICollection<CustomerDto> GetAll();
        void Update(CustomerDto cDto);
        void Delete(Guid id);
    }
}
