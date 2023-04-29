using AutoMapper;
using Order.Application.Models;
using Order.Application.Services.Interfaces;
using Order.Infostracture.Repositories.Interfaces;

namespace Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<ViewOrderModel>> GetOrdersAsync(CancellationToken cancellationToken) => 
            _mapper.Map<List<ViewOrderModel>>(await _orderRepository.GetOrdersAsync(cancellationToken));
            
        public async Task<ViewOrderModel> GetOrderByIdAsync(int id, CancellationToken cancellationToken) => 
            _mapper.Map<ViewOrderModel>(await _orderRepository.GetOrderByIdAsync(id, cancellationToken));
        
        public async Task<ViewOrderModel> CreateOrderAsync(CreateOrderModel order, CancellationToken cancellationToken)
        {
            if(order is null)
                throw new ArgumentNullException(nameof(order));

            var createdOrder = await _orderRepository.CreateOrderAsync(_mapper.Map<Order.Domain.Entities.Order>(order), cancellationToken);

            if (createdOrder is null)
                throw new ArgumentNullException(nameof(createdOrder));

            return _mapper.Map<ViewOrderModel>(createdOrder);
        }

        public async Task<ViewOrderModel> DeleteOrderAsync(int id, CancellationToken cancellationToken) => 
            _mapper.Map<ViewOrderModel>(await _orderRepository.DeleteOrderAsync(id, cancellationToken));
    }
}
