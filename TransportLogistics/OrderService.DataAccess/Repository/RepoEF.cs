using TransportLogistics.Domain.Models;

namespace OrderService.DataAccess.Repository
{
    public class RepoEF<T> : IRepository<T> where T : BaseTab
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        protected readonly AppFactory _appFactory;

        public RepoEF(AppFactory appFactory)
        {
            _appFactory = appFactory ?? throw new Exception("Ошибка при работе с БД");
        }

        /// <summary>
        /// Получить все записи из таблицы.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> AllBase => _appFactory.Set<T>();


        /// <summary>
        /// Виртуальный метод получения всех записей из таблицы 
        /// Переопределяется для зависимых таблиц
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> Get()
        {
            return await _appFactory.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Получить запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> Get(Guid id)
        {
            return await _appFactory.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// Добавить новую запись
        /// </summary>
        /// <param name="entity">Образ записи</param>
        /// <returns>
        /// Присвоенный Guid - в случае успешного добавления записи
        /// Guid.Empty - если запись с таким id уже существует
        /// </returns>
        public async Task<Guid> Add(T entity)
        {
            var existEntity = _appFactory.Set<T>().CountAsync(x => x.Id == entity.Id).Result;
            if (existEntity == 0)
            {
                await _appFactory.Set<T>().AddAsync(entity);
                _appFactory.SaveChanges();
                return entity.Id;
            }
            return Guid.Empty;
        }


        /// <summary>
        /// Обновить запись 
        /// </summary>
        /// <param name="entity">Образ записи</param>
        /// <returns></returns>
        public virtual Task<bool> Update(T entity) { return Task.FromResult(false); }
       

        /// <summary>
        /// Удалить запись по id
        /// </summary>
        /// <param name="id">id для удаления</param>
        /// <returns></returns>
        public virtual async Task<bool> Delete(Guid Id)
        {
            var existEntity = _appFactory.Set<T>().FirstOrDefaultAsync(x => x.Id == Id).Result;
            if (existEntity != null)
            {
                _appFactory.Set<T>().Remove(existEntity);
                await _appFactory.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
