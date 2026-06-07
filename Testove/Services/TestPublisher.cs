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
    public class TestPublisher
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddAndGetAllCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            PublisherController controller = new PublisherController(context);

            Publisher publisher = new Publisher
            {
                Name = "Ciela",
                Country = "Bulgaria"
            };

            await controller.AddAsync(publisher);

            var publishers = await controller.GetAllAsync();
            Assert.That(publishers.Count, Is.EqualTo(1));
            Assert.That(publishers[0].Name, Is.EqualTo("Ciela"));
            Assert.That(publishers[0].Country, Is.EqualTo("Bulgaria"));
        }

        [Test]
        public async Task TestUpdateCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            PublisherController controller = new PublisherController(context);

            Publisher original = new Publisher
            {
                Name = "Old Name",
                Country = "UK"
            };
            await controller.AddAsync(original);

            Publisher updatedData = new Publisher
            {
                Name = "New Name",
                Country = "USA"
            };

            await controller.UpdateAsync(original.Id, updatedData);

            var publishers = await controller.GetAllAsync();
            var checkPublisher = publishers.FirstOrDefault(p => p.Id == original.Id);

            Assert.That(checkPublisher, Is.Not.Null);
            Assert.That(checkPublisher!.Name, Is.EqualTo("New Name"));
            Assert.That(checkPublisher.Country, Is.EqualTo("USA"));
        }

        [Test]
        public async Task TestDeleteCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            PublisherController controller = new PublisherController(context);

            Publisher publisher = new Publisher
            {
                Name = "To Be Deleted",
                Country = "Germany"
            };
            await controller.AddAsync(publisher);

            await controller.DeleteAsync(publisher.Id);

            var publishers = await controller.GetAllAsync();
            Assert.That(publishers.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task TestDelete_ShouldDoNothing_WhenPublisherDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            PublisherController controller = new PublisherController(context);

            Publisher publisher = new Publisher
            {
                Name = "Safe Publisher",
                Country = "France"
            };
            await controller.AddAsync(publisher);

            await controller.DeleteAsync(-1);

            var publishers = await controller.GetAllAsync();
            Assert.That(publishers.Count, Is.EqualTo(1)); 
        }

        [Test]
        public async Task TestGetAll_ShouldIncludeBooks_WhenPublisherHasBooks()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            PublisherController publisherController = new PublisherController(context);

            Publisher publisher = new Publisher { Name = "Bard", Country = "Bulgaria" };
            await publisherController.AddAsync(publisher);

            Book book = new Book
            {
                Title = "Fantasy Book",
                Genre = "Fantasy",
                Price = 20m,
                Pages = 300,
                Quantity = 5,
                PublishedOn = DateOnly.FromDateTime(DateTime.Now),
                AuthorId = 1, 
                PublisherId = publisher.Id 
            };
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            var result = await publisherController.GetAllAsync();

            Assert.That(result[0].Books, Is.Not.Null);
            Assert.That(result[0].Books.Count, Is.EqualTo(1));
            Assert.That(result[0].Books.First().Title, Is.EqualTo("Fantasy Book"));
        }
    }
}
