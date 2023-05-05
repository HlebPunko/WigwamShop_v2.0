using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Models;
using Order.Application.Services.Interfaces;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var orders = await _orderService.GetOrdersAsync(HttpContext.RequestAborted);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id, HttpContext.RequestAborted);

            return Ok(order);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderModel order)
        {
            var createdOrder = await _orderService.CreateOrderAsync(order, HttpContext.RequestAborted);

            return Ok(createdOrder);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int id)
        {
            var deletedOrder = await _orderService.DeleteOrderAsync(id, HttpContext.RequestAborted);

            return Ok(deletedOrder);
        }
    }
}
