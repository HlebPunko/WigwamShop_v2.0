using AutoMapper;
using Favorite.Application.Models;
using Favorite.Application.Services.Interfaces;
using Favorite.Infostructure.Repositories.Interfaces;

namespace Favorite.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repository;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ViewFavoriteModel>> GetFavoritesAsync(CancellationToken cancellationToken) =>
            _mapper.Map<List<ViewFavoriteModel>>(await _repository.GetFavoritesAsync(cancellationToken));

        public async Task<ViewFavoriteModel> GetFavoriteByIdAsync(int id, CancellationToken cancellationToken) => 
            _mapper.Map<ViewFavoriteModel>(await _repository.GetFavoriteByIdAsync(id, cancellationToken));

        public async Task<ViewFavoriteModel> CreateFavoriteAsync(CreateFavoriteModel favorite, CancellationToken cancellationToken)
        {
            if (favorite is null)
                throw new ArgumentNullException(nameof(favorite));

            var createdFavorite = await _repository.CreateFavoriteAsync(_mapper.Map<Domain.Entities.Favorite>(favorite), cancellationToken);

            if (createdFavorite is null)
                throw new ArgumentNullException(nameof(createdFavorite));

            return _mapper.Map<ViewFavoriteModel>(createdFavorite);
        }

        public async Task<ViewFavoriteModel> DeleteFavoriteAsync(int id, CancellationToken cancellationToken)
        {
            if(id == default)
                throw new ArgumentException(nameof(id), "id is default or empty");

            var deleted = await _repository.DeleteFavoriteAsync(id, cancellationToken);

            return _mapper.Map<ViewFavoriteModel>(deleted);
        }
    }
}
