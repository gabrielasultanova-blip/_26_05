using _26_05;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testove.Helpers
{
    public class TestOnlineShopDb
    {
        public static OnlineShop_Db CreateContext()
        {
            var options = new DbContextOptionsBuilder<OnlineShop_Db>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            OnlineShop_Db context = new OnlineShop_Db(options);
            
            context.Database.EnsureCreated();

            return context;
        }
    }
}
