using Catalog.Application.Models;
using Catalog.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<VievWigwamModel>>> GetWigwams(CancellationToken cancellationToken)
        {
            var wigwams = await _catalogService.GetAllWigwams(cancellationToken);

            return Ok(wigwams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VievWigwamModel>> GetWigwam([FromRoute] int id, CancellationToken cancellationToken)
        {
            var wigwam = await _catalogService.GetWigwamById(id, cancellationToken);

            return Ok(wigwam);
        }
    }
}
