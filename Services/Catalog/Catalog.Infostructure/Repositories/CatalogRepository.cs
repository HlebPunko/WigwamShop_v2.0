using Catalog.Domain.Entities;
using Catalog.Infostructure.Context;
using Catalog.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infostructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogDbContext _context;

        public CatalogRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Wigwam>> GetAllWigwams(CancellationToken cancellationToken) => 
            await _context.Set<Wigwam>().AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Wigwam> GetWigwamById(int id, CancellationToken cancellationToken) => 
            await _context.Set<Wigwam>().AsNoTracking().FirstOrDefaultAsync(x => x.WigwamId == id, cancellationToken);
    }
}
