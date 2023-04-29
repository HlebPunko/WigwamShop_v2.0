using AutoMapper;
using Order.Application.Models;

namespace Order.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderModel, Order.Domain.Entities.Order>();
            CreateMap<UpdateOrderModel, Order.Domain.Entities.Order>();
            CreateMap<Order.Domain.Entities.Order, ViewOrderModel>();
        }
    }
}
