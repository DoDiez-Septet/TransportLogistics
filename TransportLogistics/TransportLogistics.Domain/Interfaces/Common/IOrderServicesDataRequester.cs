using TransportLogistics.Domain.Models.Order;

namespace TransportLogistics.Domain.Interfaces.Common;

public interface IOrderServicesDataRequester
{
    public Task<IEnumerable<Orders>> GetAll();
}