using _26_05;
using _26_05.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Business
{
    public class OrderItemController
    {
        private OnlineShop_Db context { get; set; }

        public OrderItemController()
        {
            context = new OnlineShop_Db();
        }
        public OrderItemController(OnlineShop_Db context_1)
        {
            context = context_1;
        }
        public async Task AddAsync(OrderItem orderItem)
        {
            await context.OrderItems.AddAsync(orderItem);
            await context.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Book)
                .ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Book)
                .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task UpdateAsync(int id, OrderItem updated)
        {
            var item = await context.OrderItems.FindAsync(id);

            item.Quantity = updated.Quantity;
            item.OrderId = updated.OrderId;
            item.BookId = updated.BookId;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await context.OrderItems.FindAsync(id);

            if (orderItem != null)
            {
                context.OrderItems.Remove(orderItem);
                await context.SaveChangesAsync();
            }
        }
    }
}
