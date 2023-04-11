using Catalog.Application.Models;
using Catalog.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WigwamsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public WigwamsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("list-wigwams")]
        public async Task<ActionResult<List<VievWigwamModel>>> GetWigwams(CancellationToken cancellationToken)
        {
            var wigwams = await _catalogService.GetAllWigwams(cancellationToken);

            return Ok(wigwams);
        }

        [HttpGet("wigwam/{id}")]
        public async Task<ActionResult<VievWigwamModel>> GetWigwam([FromRoute] int id, CancellationToken cancellationToken)
        {
            var wigwam = await _catalogService.GetWigwamById(id, cancellationToken);

            return Ok(wigwam);
        }
    }
}
