using Npgsql;
using Solution.BL.Interfaces;
using Solution.DAL;
using Solution.DAL.IRepository;
using Solution.DAL.Models;

namespace Solution.BL.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await orderRepository.GetAllOrder();
    }

    public async Task<Order> GetOrderById(int id)
    {
        var order = await orderRepository.GetOrderById(id);
        if (order == null)
        {
            throw new Exception($"Order with id {id} not found");
        }

        return order;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        // Validations (if any)

        await orderRepository.CreateOrder(order);

        return order;
    }

    public async Task<Order> UpdateOrder(Order updatedOrder)
    {
        var existingOrder = await orderRepository.GetOrderById(updatedOrder.Id);

        if (existingOrder == null)
        {
            throw new ArgumentException($"Order with id {updatedOrder.Id} not found");
        }

        existingOrder.Number = updatedOrder.Number;
        existingOrder.Date = updatedOrder.Date;
        existingOrder.ProviderId = updatedOrder.ProviderId;

        await orderRepository.UpdateOrder(existingOrder);

        return existingOrder;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var order = await orderRepository.GetOrderById(id);

        if (order == null)
        {
            throw new ArgumentException($"Order with ID {id} was not found.");
        }

        await orderRepository.DeleteOrder(id);
        return true;
    }
}