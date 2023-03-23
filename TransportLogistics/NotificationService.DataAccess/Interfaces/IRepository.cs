using NotificationService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.DataAccess.Interfaces
{
    public interface IRepository<T> where T : TableBase
    {
        public IEnumerable<T> AllBase { get; }
        public Task<List<T>> Get();
        public Task<T> Get(Guid id);
        public Task<Guid> Add(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(Guid id);
    }
}
