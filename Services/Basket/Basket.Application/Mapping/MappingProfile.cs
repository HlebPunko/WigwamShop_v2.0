using AutoMapper;
using Basket.Application.Models;
using Basket.Domain.Entities;

namespace Basket.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Wigwam, VievWigwamModel>();
        }
    }
}
