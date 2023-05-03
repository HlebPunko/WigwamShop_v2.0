using AutoMapper;
using Basket.Application.Models;
using Basket.Application.Services.Interfaces;
using Basket.Domain.Entities;
using Basket.Infostructure.Repositories.Interfaces;

namespace Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VievWigwamModel>> GetAllWigwams(CancellationToken cancellationToken)
        {
            var listWigwams = await _repository.GetAllWigwams(cancellationToken);

            return _mapper.Map<List<VievWigwamModel>>(listWigwams);
        }

        public async Task<VievWigwamModel> GetWigwamById(int id, CancellationToken cancellationToken)
        {
            var wigwam = await _repository.GetWigwamById(id, cancellationToken);

            return _mapper.Map<VievWigwamModel>(wigwam);
        }

        public async Task<VievWigwamModel> CreateWigwam(CreateWigwamModel wigwam, CancellationToken cancellationToken)
        {
            if(wigwam is null)
                throw new ArgumentNullException(nameof(wigwam), "wigwam model is null");

            var created = await _repository.CreateWigwam(_mapper.Map<Wigwam>(wigwam), cancellationToken);

            if (created is null)
                throw new ArgumentNullException(nameof(created), "Wigwam is not created");

            return _mapper.Map<VievWigwamModel>(created);
        }

        public async Task<int> DeleteWigwam(int id, CancellationToken cancellationToken)
        {
            if (id == default)
                throw new ArgumentNullException(nameof(id), "id is empty or default");

            var deletedId = await _repository.DeleteWigwam(await _repository.GetWigwamById(id, cancellationToken), cancellationToken);

            if (deletedId == default)
                throw new ArgumentNullException(nameof(deletedId), "deleted id is default");

            return deletedId;
        }
    }
}
