using AutoMapper;
using Favorite.Application.Models;

namespace Favorite.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFavoriteModel, Domain.Entities.Favorite>();
            CreateMap<Domain.Entities.Favorite, ViewFavoriteModel>();
        }
    }
}
