using AutoMapper;
using SitNSleep.Services.Dtos;
using SitNSleep.Web.Models;

namespace SitNSleep.Web.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<SalesPersonModel, SalesPersonDto>().ReverseMap();
            CreateMap<StoreModel, StoreDto>().ReverseMap();
        }
    }
}
