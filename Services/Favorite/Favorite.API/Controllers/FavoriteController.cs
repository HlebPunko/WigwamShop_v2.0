using Favorite.Application.Models;
using Favorite.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Favorite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _service;

        public FavoriteController(IFavoriteService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ViewFavoriteModel>>> GetFavorites()
        {
            var favorites = await _service.GetFavoritesAsync(HttpContext.RequestAborted);

            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewFavoriteModel>> GetFavoriteById([FromRoute] int id)
        {
            var favorite = await _service.GetFavoriteByIdAsync(id, HttpContext.RequestAborted);

            return Ok(favorite);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ViewFavoriteModel>> Create([FromBody] CreateFavoriteModel favorite)
        {
            var created = await _service.CreateFavoriteAsync(favorite, HttpContext.RequestAborted);

            return Ok(created);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ViewFavoriteModel>> Delete([FromRoute] int id)
        {
            var deleted = await _service.DeleteFavoriteAsync(id, HttpContext.RequestAborted);

            return Ok(deleted);
        }
    }
}
