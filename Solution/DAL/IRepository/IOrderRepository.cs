using Solution.DAL.Models;

namespace Solution.DAL.IRepository;

public interface IOrderRepository
{
    Task<Order> GetOrderById(int id);
    Task<List<Order>> GetAllOrder();
    
    Task CreateOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(int id);
}