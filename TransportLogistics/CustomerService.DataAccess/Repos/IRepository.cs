using CustomerService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.DataAccess.Repos
{
    public interface IRepository
    {
    }

    public interface IRepository<T, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
    {
        IQueryable<T> GetAll();

        T GetByPrimaryKey(TPrimaryKey id);
        bool Delete(TPrimaryKey id);
        bool Delete(T entity);
        bool Update(T entity);
        T Add(T entity);
        void SaveChanges();
    }
}
