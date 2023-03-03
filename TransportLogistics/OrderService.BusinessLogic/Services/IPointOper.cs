using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Interfaces;

namespace OrderService.BusinessLogic.Services
{
    public interface IPointOper
    {
        public Task<List<IPoint>> Get(string pointname = "");
        public Task Add(IPoint point);
        public Task<bool> Update(IPoint point);
        public Task<bool> Delete(string pointName);
    }
}
