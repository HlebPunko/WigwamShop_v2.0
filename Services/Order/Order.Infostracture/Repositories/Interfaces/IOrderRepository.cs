using Order.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Order.Infostracture.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order.Domain.Entities.Order>> GetOrdersAsync(CancellationToken cancellationToken);
        Task<Order.Domain.Entities.Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
        Task<Order.Domain.Entities.Order> CreateOrderAsync(Order.Domain.Entities.Order order, CancellationToken cancellationToken);
        Task<Order.Domain.Entities.Order> DeleteOrderAsync(int id, CancellationToken cancellationToken);
    }
}
