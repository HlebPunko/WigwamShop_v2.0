using Favorite.Infostructure.Context;
using Favorite.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Favorite.Infostructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly FavoriteDbContext _context;

        public FavoriteRepository(FavoriteDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Favorite> CreateFavoriteAsync(Domain.Entities.Favorite favorite, CancellationToken cancellationToken)
        {
            var addedOrder = await _context.Set<Domain.Entities.Favorite>().AddAsync(favorite, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return addedOrder.Entity;
        }

        public async Task<Domain.Entities.Favorite> DeleteFavoriteAsync(int id, CancellationToken cancellationToken)
        {
            var deletedOrder = _context.Set<Domain.Entities.Favorite>().Remove(await GetFavoriteByIdAsync(id, cancellationToken));

            await _context.SaveChangesAsync(cancellationToken);

            return deletedOrder.Entity;
        }

        public async Task<Domain.Entities.Favorite> GetFavoriteByIdAsync(int id, CancellationToken cancellationToken) =>
            await _context.Set<Domain.Entities.Favorite>().AsNoTracking().FirstOrDefaultAsync(x => x.WigwamId == id, cancellationToken);

        public async Task<List<Domain.Entities.Favorite>> GetFavoritesAsync(CancellationToken cancellationToken) =>
            await _context.Set<Domain.Entities.Favorite>().AsNoTracking().ToListAsync(cancellationToken);
    }
}
