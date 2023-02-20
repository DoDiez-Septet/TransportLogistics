using CustomerService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DataAccess.Deprecated
{
    public class Repository
    {
    }

    /// <summary>
    /// Репозиторий чтения и записи
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
    public abstract class Repository<T, TPrimaryKey> : IRepository<T, TPrimaryKey> where T : class, IEntity<TPrimaryKey>
    {
        protected readonly DbContext Context;
        protected DbSet<T> EntitySet;

        protected Repository(DbContext context)
        {
            Context = context;
            EntitySet = Context.Set<T>();
        }

        /// <summary>
        /// Запросить все сущности в базе
        /// </summary>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>IQueryable массив сущностей</returns>
        public virtual IQueryable<T> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ? EntitySet.AsNoTracking() : EntitySet;
        }

        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>сущность</returns>
        public virtual T Get(TPrimaryKey id)
        {
            return EntitySet.Find(id);
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">ID удалённой сущности</param>
        /// <returns>была ли сущность удалена</returns>
        public virtual bool Delete(TPrimaryKey id)
        {
            var obj = EntitySet.Find(id);
            if (obj == null)
            {
                return false;
            }
            EntitySet.Remove(obj);
            return true;
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">сущность для удаления</param>
        /// <returns>была ли сущность удалена</returns>
        public virtual bool Delete(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            Context.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// Для сущности проставить состояние - что она изменена
        /// </summary>
        /// <param name="entity">сущность для изменения</param>
        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        public virtual T Add(T entity)
        {
            var objToReturn = Context.Set<T>().Add(entity);
            return objToReturn.Entity;
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public virtual T GetByPrimaryKey(TPrimaryKey id)
        {
            return EntitySet.Find(id);
        }

        bool IRepository<T, TPrimaryKey>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
