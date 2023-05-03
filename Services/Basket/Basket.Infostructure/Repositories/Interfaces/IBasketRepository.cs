using Basket.Domain.Entities;

namespace Basket.Infostructure.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Wigwam>> GetAllWigwams(CancellationToken cancellationToken);
        Task<Wigwam> GetWigwamById(int id, CancellationToken cancellationToken);
        Task<Wigwam> CreateWigwam(Wigwam wigwam, CancellationToken cancellationToken);
        Task<int> DeleteWigwam(Wigwam wigwam, CancellationToken cancellationToken);
    }
}
