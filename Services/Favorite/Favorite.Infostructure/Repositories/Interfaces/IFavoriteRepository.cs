namespace Favorite.Infostructure.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<List<Domain.Entities.Favorite>> GetFavoritesAsync(CancellationToken cancellationToken);
        Task<Domain.Entities.Favorite> GetFavoriteByIdAsync(int id, CancellationToken cancellationToken);
        Task<Domain.Entities.Favorite> CreateFavoriteAsync(Domain.Entities.Favorite favorite, CancellationToken cancellationToken);
        Task<Domain.Entities.Favorite> DeleteFavoriteAsync(int id, CancellationToken cancellationToken);
    }
}
