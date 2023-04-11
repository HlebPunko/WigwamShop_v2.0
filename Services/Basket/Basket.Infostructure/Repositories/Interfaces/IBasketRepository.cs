using Basket.Domain.Entities;

namespace Basket.Infostructure.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Wigwam>> GetAllWigwams(CancellationToken cancellationToken);
        Task<Wigwam> GetWigwamById(int id, CancellationToken cancellationToken);
    }
}
