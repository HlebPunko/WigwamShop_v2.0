using Catalog.Application.Models;

namespace Catalog.Application.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<VievWigwamModel>> GetAllWigwams(CancellationToken cancellationToken);
        Task<VievWigwamModel> GetWigwamById(int id, CancellationToken cancellationToken);
    }
}
