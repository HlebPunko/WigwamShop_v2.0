using AutoMapper;
using Catalog.Application.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Wigwam, VievWigwamModel>();
        }
    }
}
