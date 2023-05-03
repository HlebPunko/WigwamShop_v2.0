using Basket.Domain.Entities;
using Basket.Infostructure.Context;
using Basket.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infostructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _context;

        public BasketRepository(BasketDbContext context)
        {
            _context = context;
        }

        public async Task<List<Wigwam>> GetAllWigwams(CancellationToken cancellationToken) => 
            await _context.Set<Wigwam>().AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Wigwam> GetWigwamById(int id, CancellationToken cancellationToken) => 
            await _context.Set<Wigwam>().AsNoTracking().FirstOrDefaultAsync(x => x.WigwamId == id, cancellationToken);

        public async Task<Wigwam> CreateWigwam(Wigwam wigwam, CancellationToken cancellationToken)
        {
            var createdWigwam = await _context.basket.AddAsync(wigwam, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return createdWigwam.Entity;
        }

        public async Task<int> DeleteWigwam(Wigwam wigwam, CancellationToken cancellationToken)
        {
            var deletedWigwam = _context.basket.Remove(wigwam);

            await _context.SaveChangesAsync(cancellationToken);

            return deletedWigwam.Entity.WigwamId;
        }
    }
}
