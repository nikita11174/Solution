using Microsoft.AspNetCore.Mvc;
using Solution.BL.Interfaces;
using Solution.DAL.Models;
using System.Threading.Tasks;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsс(int id)
        {
            var order = await orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrderAsync(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrder = await orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderByIdAsс), new { id = createdOrder.Id }, createdOrder);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var result = await orderService.UpdateOrder(order);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var result = await orderService.DeleteOrder(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}