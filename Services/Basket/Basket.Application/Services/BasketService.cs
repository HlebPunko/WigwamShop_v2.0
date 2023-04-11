using AutoMapper;
using Basket.Application.Models;
using Basket.Application.Services.Interfaces;
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
    }
}
