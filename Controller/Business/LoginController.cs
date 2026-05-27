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
    public class LogInController
    {
        public OnlineShop_Db context = new OnlineShop_Db();

        public async Task<User> Login(string username, string password)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        }
    }
}
