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
    public class UserController
    {
        public OnlineShop_Db context = new OnlineShop_Db();

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users
                .Include(u => u.Orders)
                .ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        // Filtering

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await context.Orders
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllAdminsAsync()
        {
            return await context.Users
                .Where(u => u.Role == Role.Admin)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.Users
                .Where(u => u.Role == Role.User)
                .ToListAsync();
        }
    }
}
