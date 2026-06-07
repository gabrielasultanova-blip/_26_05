using _26_05.Entities;
using _26_05;
using Controller.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testove.Helpers;

namespace Testove.Services
{
    public class TestBook
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddAndGetAllCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            Book book = new Book
            {
                Title = "Pod Igoto",
                Genre = "Novel",
                Price = 15.50m,
                Pages = 400,
                Quantity = 10,
                InStock = true,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id
            };

            await controller.AddAsync(book);

            var books = await controller.GetAllAsync();
            Assert.That(books.Count, Is.EqualTo(1));
            Assert.That(books[0].Title, Is.EqualTo("Pod Igoto"));
        }

        [Test]
        public async Task TestGetByIdCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };

            Book book = new Book
            {
                Title = "Harry Potter",
                Genre = "Fantasy",
                Price = 20.00m,
                Pages = 350,
                Quantity = 5,
                InStock = true,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                Author = author,
                Publisher = publisher
            };

            await controller.AddAsync(book);

            Book? dbBook = await controller.GetByIdAsync(book.Id);
            Assert.That(dbBook, Is.Not.Null);
            Assert.That(dbBook!.Title, Is.EqualTo("Harry Potter"));
        }

        [Test]
        public async Task TestUpdateCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            Book originalBook = new Book
            {
                Title = "Old Title",
                Genre = "Drama",
                Price = 10.00m,
                Pages = 150,
                Quantity = 2,
                InStock = true,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id
            };
            await controller.AddAsync(originalBook);

            Book updatedData = new Book
            {
                Title = "New Title",
                Genre = "Action",
                Price = 12.50m,
                Pages = 160,
                Quantity = 5,
                InStock = true,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id
            };

            await controller.UpdateAsync(originalBook.Id, updatedData);

            Book? checkBook = await controller.GetByIdAsync(originalBook.Id);
            Assert.That(checkBook, Is.Not.Null);
            Assert.That(checkBook!.Title, Is.EqualTo("New Title"));
        }

        [Test]
        public async Task TestDeleteCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            Book book = new Book
            {
                Title = "To Be Deleted",
                Genre = "Horror",
                Price = 5.00m,
                Pages = 100,
                Quantity = 1,
                InStock = true,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id
            };
            await controller.AddAsync(book);

            await controller.DeleteAsync(book.Id);

            var books = await controller.GetAllAsync();
            Assert.That(books.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task TestDelete_ShouldDoNothing_WhenBookDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            Book book = new Book
            {
                Title = "Safe Book",
                Genre = "Sci-Fi",
                Price = 9.99m,
                Pages = 200,
                Quantity = 4,
                InStock = true,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id
            };
            await controller.AddAsync(book);

            await controller.DeleteAsync(9999);

            var books = await controller.GetAllAsync();
            Assert.That(books.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestGetBooksByGenre()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            await controller.AddAsync(new Book { Title = "B1", Genre = "Fantasy", Price = 10, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });
            await controller.AddAsync(new Book { Title = "B2", Genre = "Horror", Price = 10, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });
            await controller.AddAsync(new Book { Title = "B3", Genre = "Fantasy", Price = 10, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });

            List<Book> result = await controller.GetBooksByGenreAsync("Fantasy");
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TestGetBooksByPriceRange()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            await controller.AddAsync(new Book { Title = "Cheap", Price = 5.00m, Genre = "G", Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });
            await controller.AddAsync(new Book { Title = "Medium", Price = 15.00m, Genre = "G", Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });
            await controller.AddAsync(new Book { Title = "Expensive", Price = 50.00m, Genre = "G", Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });

            List<Book> result = await controller.GetBooksByPriceRangeAsync(10.00m, 20.00m);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Title, Is.EqualTo("Medium"));
        }

        [Test]
        public async Task TestGetBookByTitle()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            await controller.AddAsync(new Book { Title = "Target Title", Genre = "G", Price = 10, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });

            Book result = await controller.GetBookByTitleAsync("Target Title");
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Title, Is.EqualTo("Target Title"));
        }

        [Test]
        public async Task TestStockFilters()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            await controller.AddAsync(new Book { Title = "Available", InStock = true, Genre = "G", Price = 10, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });
            await controller.AddAsync(new Book { Title = "Sold Out", InStock = false, Genre = "G", Price = 10, Pages = 100, Quantity = 0, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = author.Id, PublisherId = publisher.Id });

            var inStock = await controller.IsInStockAsync();
            var outOfStock = await controller.IsNotInStockAsync();

            Assert.That(inStock.Count, Is.EqualTo(1));
            Assert.That(inStock[0].Title, Is.EqualTo("Available"));

            Assert.That(outOfStock.Count, Is.EqualTo(1));
            Assert.That(outOfStock[0].Title, Is.EqualTo("Sold Out"));
        }

        [Test]
        public async Task TestGetBooksByAuthorsName()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            Author author = new Author { FirstName = "Ivan", LastName = "Vazov", Age = 70, Nationality = "BG" };
            var publisher = new Publisher { Name = "Pub", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            Book book = new Book
            {
                Title = "Chichovci",
                Genre = "Classic",
                Price = 12.00m,
                Pages = 250,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id,
                Quantity = 5,
                InStock = true
            };

            await controller.AddAsync(book);

            List<Book> result = await controller.GetBooksByAuthorsNameAsync("Ivan Vazov");

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Title, Is.EqualTo("Chichovci"));
        }


        [Test]
        public async Task TestGetBooksByPublisher()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            BookController controller = new BookController(context);

            var author = new Author { FirstName = "A", LastName = "B", Age = 20, Nationality = "BG" };
            Publisher publisher = new Publisher { Name = "Ciela", Country = "UK" };
            await context.Authors.AddAsync(author);
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();

            Book book = new Book
            {
                Title = "Some Book",
                Genre = "G",
                Price = 10.00m,
                Pages = 180,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = author.Id,
                PublisherId = publisher.Id,
                Quantity = 10,
                InStock = true
            };

            await controller.AddAsync(book);

            List<Book> result = await controller.GetBooksByPublisherAsync("Ciela");

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Title, Is.EqualTo("Some Book"));
        }

    }

}