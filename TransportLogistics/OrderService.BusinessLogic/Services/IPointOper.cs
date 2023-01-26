using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.BusinessLogic.Services
{
    public interface IPointOper
    {
        public Task<List<IPoint>> Get(string pointname = "");
        public Task Add(IPoint point);
    }
}
