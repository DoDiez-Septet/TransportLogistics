using CustomerService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.DataAccess.Repos
{
    public class CustomerRepo : Repository<Customer, Guid>
    {
        CustomerRepo(DbContext dbContext) : base(dbContext) { }
    }
}
