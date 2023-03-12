using AutoMapper;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.DataAccess
{
    internal class MapProfiler : Profile
    {
        public MapProfiler()
        {
            CreateMap<OrdersDb, Orders>().ReverseMap();
        }
    }
}
