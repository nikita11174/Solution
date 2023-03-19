using Microsoft.EntityFrameworkCore;
using Solution.DAL.IRepository;
using Solution.DAL.Models;

namespace Solution.DAL;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext context;

    public OrderRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Order> GetOrderById(int id)
    {
        return await context.Orders.FindAsync(id);
    }

    public async Task<List<Order>> GetAllOrder()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task CreateOrder(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }


    public async Task UpdateOrder(Order order)
    {
        context.Entry(order).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrder(int id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order != null)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }
}