namespace OrderService.DataAccess.Repository
{
    public interface IRepository<T> where T : TableBase
    {
        public IEnumerable<T> AllBase { get; }
        public Task<List<T>> Get();
        public Task<T> Get(Guid id);
        public Task<Guid> Add(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(T entity);
    }
}
