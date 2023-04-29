using Order.Infostructure.Context;
using Microsoft.EntityFrameworkCore;
using Order.Infostracture.Repositories.Interfaces;
using System.Text;
using System;

namespace Order.Infostracture.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.Entities.Order>> GetOrdersAsync(CancellationToken cancellationToken) => 
            await _context.Set<Order.Domain.Entities.Order>().AsNoTracking().ToListAsync(cancellationToken);
        

        public async Task<Domain.Entities.Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken) => 
            await _context.Set<Order.Domain.Entities.Order>().AsNoTracking().FirstOrDefaultAsync(x => x.OrderId == id, cancellationToken);
        

        public async Task<Order.Domain.Entities.Order> CreateOrderAsync(Order.Domain.Entities.Order order, CancellationToken cancellationToken)
        {
            var addedOrder = await _context.Set<Order.Domain.Entities.Order>().AddAsync(order, cancellationToken);

            await _context.SaveChangesAsync();

            return addedOrder.Entity;
        }

        public async Task<Order.Domain.Entities.Order> DeleteOrderAsync(int id, CancellationToken cancellationToken)
        {
            var deletedOrder = _context.Set<Order.Domain.Entities.Order>().Remove(await GetOrderByIdAsync(id, cancellationToken));

            await _context.SaveChangesAsync();

            return deletedOrder.Entity;
        }
    }
}
