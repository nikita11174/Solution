using Solution.DAL.Models;

namespace Solution.BL.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> GetOrderById(int id);
    Task<Order> CreateOrder(Order order);
    Task<bool> UpdateOrder(Order order);
    Task<bool> DeleteOrder(int id);
}