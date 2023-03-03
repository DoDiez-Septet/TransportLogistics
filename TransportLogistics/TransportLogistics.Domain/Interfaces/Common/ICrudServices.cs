
namespace TransportLogistics.Domain.Interfaces.Common;

public interface ICrudServices<T>
{
    public IEnumerable<T> GetAll();

    public T GetById(string Id);

    public string New(T entity);

    public T Edit(T entity);

    public void Delete(string Id);
}