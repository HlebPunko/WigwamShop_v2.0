using Order.Application.Models;

namespace Order.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<ViewOrderModel>> GetOrdersAsync(CancellationToken cancellationToken);
        Task<ViewOrderModel> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
        Task<ViewOrderModel> CreateOrderAsync(CreateOrderModel order, CancellationToken cancellationToken);
        Task<ViewOrderModel> DeleteOrderAsync(int id, CancellationToken cancellationToken);
    }
}
