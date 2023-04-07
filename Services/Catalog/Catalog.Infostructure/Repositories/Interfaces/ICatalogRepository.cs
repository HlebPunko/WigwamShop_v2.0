using Catalog.Domain.Entities;

namespace Catalog.Infostructure.Repositories.Interfaces
{
    public interface ICatalogRepository
    {
        Task<List<Wigwam>> GetAllWigwams(CancellationToken cancellationToken);
        Task<Wigwam> GetWigwamById(int id, CancellationToken cancellationToken);
    }
}
