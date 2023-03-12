using AutoMapper;
using TransportLogistics.Domain.Models.Customers;
using CustomerService.DataAccess.Models;

namespace CustomerService.DataAccess;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CustomerDb, Customer>().ReverseMap();
    }
}
