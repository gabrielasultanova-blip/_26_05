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
        private OnlineShop_Db context { get; set; }

        public LogInController()
        {
            context = new OnlineShop_Db();
        }
        public LogInController(OnlineShop_Db context_1)
        {
            context = context_1;
        }

        public async Task<User> Login(string username, string password)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        }
    }
}
