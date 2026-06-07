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
    public class BookController
    {
        private OnlineShop_Db context { get; set; }

        public BookController()
        {
            context = new OnlineShop_Db();
        }
        public BookController(OnlineShop_Db context_1)
        {
            context = context_1;
        }

        public async Task AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(int id, Book updated)
        {
            var book = await context.Books.FindAsync(id);

            book.Title = updated.Title;
            book.Genre = updated.Genre;
            book.Price = updated.Price;
            book.Pages = updated.Pages;
            book.Quantity = updated.Quantity;
            book.InStock = updated.InStock;
            book.PublishedOn = updated.PublishedOn;

            book.AuthorId = updated.AuthorId;
            book.PublisherId = updated.PublisherId;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        // Filtering

        public async Task<List<Book>> GetBooksByGenreAsync(string genre)
        {
            return await context.Books
                .Where(b => b.Genre == genre)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await context.Books
                .Where(b => b.Price >= minPrice && b.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<Book?> GetBookByTitleAsync(string title)
        {
            return await context.Books
                .FirstOrDefaultAsync(b => b.Title == title);
        }

        public async Task<List<Book>> IsInStockAsync()
        {
            return await context.Books
                .Where(b => b.InStock)
                .ToListAsync();
        }

        public async Task<List<Book>> IsNotInStockAsync()
        {
            return await context.Books
                .Where(b => !b.InStock)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByAuthorsNameAsync(string authorName)
        {
            return await context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.FirstName + " " + b.Author.LastName == authorName)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByPublisherAsync(string publisherName)
        {
            return await context.Books
                .Include(b => b.Publisher)
                .Where(b => b.Publisher.Name == publisherName)
                .ToListAsync();
        }
    }
}
