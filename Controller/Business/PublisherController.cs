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
    public class PublisherController
    {
        public OnlineShop_Db context = new OnlineShop_Db();

        public async Task AddAsync(Publisher publisher)
        {
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await context.Publishers
                .Include(p => p.Books)
                .ToListAsync();
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            context.Publishers.Update(publisher);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await context.Publishers.FindAsync(id);

            if (publisher != null)
            {
                context.Publishers.Remove(publisher);
                await context.SaveChangesAsync();
            }
        }
    }
}
