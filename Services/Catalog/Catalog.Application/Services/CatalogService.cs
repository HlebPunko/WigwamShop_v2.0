using AutoMapper;
using Catalog.Application.Models;
using Catalog.Application.Services.Interfaces;
using Catalog.Infostructure.Repositories.Interfaces;

namespace Catalog.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;
        private readonly IMapper _mapper;

        public CatalogService(ICatalogRepository repository, IMapper mapper)
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
