using Npgsql;
using Solution.BL.Interfaces;
using Solution.DAL;
using Solution.DAL.IRepository;
using Solution.DAL.Models;

namespace Solution.BL.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var orders = await _repository.GetAllOrder();
        return orders.Select(o => new Order
        {
            Id = o.Id,
            Date = o.Date,
            Number = o.Number,
            ProviderId = o.ProviderId
        });
    }

    public async Task<Order> GetOrderById(int id)
    {
        var order = await _repository.GetOrderById(id);
        if (order != null)
        {
            return new Order
            {
                Id = order.Id,
                Number = order.Number,
                Date = order.Date,
                ProviderId = order.ProviderId
            };
        }

        return null;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        var newOrder = new Order
        {
            Number = order.Number,
            Date = order.Date,
            ProviderId = order.ProviderId
        };
        await _repository.CreateOrder(order);
        return order;
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        var existingOrder = await _repository.GetOrderById(order.Id);

        if (existingOrder == null)
        {
            return false;
        }

        existingOrder.Number = order.Number;
        existingOrder.ProviderId = order.ProviderId;

        await _repository.UpdateOrder(existingOrder);

        return true;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var existingOrder = await _repository.GetOrderById(id);

        if (existingOrder == null)
        {
            return false;
        }


        await _repository.DeleteOrder(id);

        return true;
    }
}