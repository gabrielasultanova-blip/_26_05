using _26_05.Entities;
using _26_05.Enums;
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
    public class TestOrderItem
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddAndGetAllCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderItemController controller = new OrderItemController(context);

            var order = new Order { OrderDate = DateTime.Now, Status = Status.Pending, UserId = 1 };
            var book = new Book { Title = "Test Book", Genre = "G", Price = 10m, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = 1, PublisherId = 1 };

            await context.Orders.AddAsync(order);
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            OrderItem item = new OrderItem
            {
                Quantity = 2,
                OrderId = order.Id,
                BookId = book.Id
            };

            await controller.AddAsync(item);

            var items = await controller.GetAllAsync();
            Assert.That(items.Count, Is.EqualTo(1));
            Assert.That(items[0].Quantity, Is.EqualTo(2));
            Assert.That(items[0].OrderId, Is.EqualTo(order.Id));
            Assert.That(items[0].BookId, Is.EqualTo(book.Id));
        }

        [Test]
        public async Task TestGetByIdCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderItemController controller = new OrderItemController(context);

            var order = new Order { OrderDate = DateTime.Now, Status = Status.Pending, UserId = 1 };
            var book = new Book { Title = "B", Genre = "G", Price = 10m, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = 1, PublisherId = 1 };

            OrderItem item = new OrderItem
            {
                Quantity = 3,
                Order = order, 
                Book = book    
            };

            await controller.AddAsync(item);

            OrderItem? dbItem = await controller.GetByIdAsync(item.Id);
            Assert.That(dbItem, Is.Not.Null);
            Assert.That(dbItem!.Id, Is.EqualTo(item.Id));
            Assert.That(dbItem.Quantity, Is.EqualTo(3));
        }

        [Test]
        public async Task TestUpdateCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderItemController controller = new OrderItemController(context);

            var order = new Order { OrderDate = DateTime.Now, Status = Status.Pending, UserId = 1 };
            var book = new Book { Title = "B", Genre = "G", Price = 10m, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = 1, PublisherId = 1 };
            await context.Orders.AddAsync(order);
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            OrderItem originalItem = new OrderItem
            {
                Quantity = 1,
                OrderId = order.Id,
                BookId = book.Id
            };
            await controller.AddAsync(originalItem);

            OrderItem updatedData = new OrderItem
            {
                Quantity = 5, 
                OrderId = order.Id,
                BookId = book.Id
            };

            await controller.UpdateAsync(originalItem.Id, updatedData);

            OrderItem? checkItem = await controller.GetByIdAsync(originalItem.Id);
            Assert.That(checkItem, Is.Not.Null);
            Assert.That(checkItem!.Quantity, Is.EqualTo(5));
        }

        [Test]
        public async Task TestDeleteCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderItemController controller = new OrderItemController(context);

            var order = new Order { OrderDate = DateTime.Now, Status = Status.Pending, UserId = 1 };
            var book = new Book { Title = "B", Genre = "G", Price = 10m, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = 1, PublisherId = 1 };
            await context.Orders.AddAsync(order);
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            OrderItem item = new OrderItem
            {
                Quantity = 1,
                OrderId = order.Id,
                BookId = book.Id
            };
            await controller.AddAsync(item);

            await controller.DeleteAsync(item.Id);

            var items = await controller.GetAllAsync();
            Assert.That(items.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task TestDelete_ShouldDoNothing_WhenOrderItemDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderItemController controller = new OrderItemController(context);

            var order = new Order { OrderDate = DateTime.Now, Status = Status.Pending, UserId = 1 };
            var book = new Book { Title = "B", Genre = "G", Price = 10m, Pages = 100, Quantity = 5, PublishedOn = DateOnly.FromDateTime(DateTime.Now), AuthorId = 1, PublisherId = 1 };
            await context.Orders.AddAsync(order);
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            OrderItem item = new OrderItem
            {
                Quantity = 1,
                OrderId = order.Id,
                BookId = book.Id
            };
            await controller.AddAsync(item);

            await controller.DeleteAsync(-1);

            var items = await controller.GetAllAsync();
            Assert.That(items.Count, Is.EqualTo(1)); 
        }
    }
}
