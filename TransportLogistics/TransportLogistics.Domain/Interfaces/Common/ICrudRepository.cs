namespace TransportLogistics.Domain.Interfaces.Common;

public interface ICrudRepository<T> where T : class
{
    void Delete(string Id);

    void Edit(string Id, T entry);

    T? Get(string Id);

    IEnumerable<T> GetAll();

    string New(T entry);
}