using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerService.DataAccess;
using AutoMapper;
using CustomerService.DataAccess.Models;

namespace CustomerService.BusinessLogic
{
    internal class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile() 
        {
            CreateMap<CustomerDb, CustomerDto>();

            CreateMap<CustomerDto, CustomerDb>();
                //.ForMember(d => d.Id, map => map.Ignore());
        }
    }
}
