using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Models
{
    public interface IRepository<T> where T : TableBase
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(int id);
        public Task<bool> Add(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
