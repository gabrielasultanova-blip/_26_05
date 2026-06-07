using _26_05;
using _26_05.Entities;
using _26_05.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Business
{
    public class OrderController
    {
        private OnlineShop_Db context { get; set; }

        public OrderController()
        {
            context = new OnlineShop_Db();
        }
        public OrderController(OnlineShop_Db context_1)
        {
            context = context_1;
        }

        public async Task AddAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);

            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }

        // Filtering

        public async Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .ToListAsync();
        }

        public async Task UpdateOrderStatus(int orderId, Status newStatus)
        {
            var order = await context.Orders.FindAsync(orderId);

            if (order != null)
            {
                order.Status = newStatus;
                await context.SaveChangesAsync();
            }
        }
    }
}
