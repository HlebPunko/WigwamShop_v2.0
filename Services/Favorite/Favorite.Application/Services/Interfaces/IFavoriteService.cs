using Favorite.Application.Models;

namespace Favorite.Application.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<List<ViewFavoriteModel>> GetFavoritesAsync(CancellationToken cancellationToken);
        Task<ViewFavoriteModel> GetFavoriteByIdAsync(int id, CancellationToken cancellationToken);
        Task<ViewFavoriteModel> CreateFavoriteAsync(CreateFavoriteModel favorite, CancellationToken cancellationToken);
        Task<ViewFavoriteModel> DeleteFavoriteAsync(int id, CancellationToken cancellationToken);
    }
}
