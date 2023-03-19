using Microsoft.AspNetCore.Mvc;
using Solution.BL.Interfaces;
using Solution.BL.Service;
using Solution.DAL.Models;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrders();
        var orderDtos = orders.Select(o => new Order
        {
            Id = o.Id,
            Number = o.Number,
            Date = o.Date,
            ProviderId = o.ProviderId
        }).ToList();

        return Ok(orderDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        var orderDto = new Order
        {
            Id = order.Id,
            Number = order.Number,
            Date = order.Date,
            ProviderId = order.ProviderId
        };

        return Ok(orderDto);
    }


    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        var createdOrder = await _orderService.CreateOrder(order);

        var orderDto = new Order
        {
            Id = createdOrder.Id,
            Number = createdOrder.Number,
            Date = createdOrder.Date,
            ProviderId = createdOrder.ProviderId
        };

        return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.Id }, orderDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Order>> UpdateOrder(int id, OrderService updateOrder)
    {
        var order = await _orderService.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        order.Number = order.Number;
        order.Date = order.Date;
        order.ProviderId = updateOrder.Pro;

        var updatedOrder = await _orderService.UpdateOrder(order);

        var orderDto = new Order
        {
            Id = updatedOrder.Id,
            CustomerName = updatedOrder.CustomerName,
            OrderDate = updatedOrder.OrderDate,
            TotalAmount = updatedOrder.TotalAmount
        };

        return Ok(orderDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        var order = await _orderService.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        await _orderService.DeleteOrder(order);

        return NoContent();
    }
}