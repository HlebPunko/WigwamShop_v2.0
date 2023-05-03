using Basket.Application.Models;
using Basket.Application.Services;
using Basket.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("basket-wigwams-list")]
        public async Task<ActionResult<VievWigwamModel>> GetWigwams(CancellationToken cancellationToken)
        {
            var wigwams = await _basketService.GetAllWigwams(cancellationToken);

            return Ok(wigwams);
        }

        [HttpGet("basket-wigwam/{id}")]
        public async Task<ActionResult<VievWigwamModel>> GetWigwam([FromRoute] int id, CancellationToken cancellationToken)
        {
            var wigwams = await _basketService.GetWigwamById(id, cancellationToken);

            return Ok(wigwams);
        }

        [HttpPost("create")]
        public async Task<ActionResult<VievWigwamModel>> CreateWigwam([FromBody] CreateWigwamModel wigwam)
        {
            var created = await _basketService.CreateWigwam(wigwam, HttpContext.RequestAborted);

            return Ok(created);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<int>> DeleteWigwam([FromRoute] int id)
        {
            var deletedId = await _basketService.DeleteWigwam(id, HttpContext.RequestAborted);

            return Ok(deletedId);
        }
    }
}
