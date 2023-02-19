using AutoMapper;
using TransportLogistics.Domain.Models.Users;
using UserService.DataAccess.ModelDb;

namespace UserService.DataAccess;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UserDb, User>().ReverseMap();
    }
}
