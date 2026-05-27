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
    public class AuthorController
    {
        public OnlineShop_Db context = new OnlineShop_Db();

        public async Task AddAsync(Author author)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await context.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            context.Authors.Update(author);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await context.Authors.FindAsync(id);

            if (author != null)
            {
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
            }
        }
    }
}
