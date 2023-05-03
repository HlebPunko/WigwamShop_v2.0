using Basket.Application.Models;

namespace Basket.Application.Services.Interfaces
{
    public interface IBasketService
    {
        Task<List<VievWigwamModel>> GetAllWigwams(CancellationToken cancellationToken);
        Task<VievWigwamModel> GetWigwamById(int id, CancellationToken cancellationToken);
        Task<int> DeleteWigwam(int id, CancellationToken cancellationToken);
        Task<VievWigwamModel> CreateWigwam(CreateWigwamModel wigwam, CancellationToken cancellationToken);
    }
}
