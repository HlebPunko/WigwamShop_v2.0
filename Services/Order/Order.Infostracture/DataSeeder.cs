using Order.Infostructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Order.Infostructure
{
    public class DataSeeder
    {
        private readonly OrderDbContext _context;

        public DataSeeder(OrderDbContext context)
        {
            _context = context;
        }

        private static IEnumerable<Order.Domain.Entities.Order> GetOrders() => new List<Order.Domain.Entities.Order>()
        {
            new Order.Domain.Entities.Order()
            {
                WigwamName = "Вигвам 1, классический вариант", 
                Count = 2,
                Price = 300m,
                UserId = 1,
                WigwamId = 1
            },
            new Order.Domain.Entities.Order()
            {
                WigwamName = "Вигвам 2, отличный вариант",
                Count = 1,
                Price = 444m,
                UserId = 2,
                WigwamId = 2
            },
        };

        public async Task InitializeDBAsync()
        {
            if (!await _context.Orders.AnyAsync())
            {
                await _context.AddRangeAsync(GetOrders());
                await _context.SaveChangesAsync();
            }
        }
    }
}
