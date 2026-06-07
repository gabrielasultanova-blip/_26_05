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
    public class TestOrder
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddAndGetAllCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "Ivan", Password = "123", Email = "ivan@test.com" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Pending, 
                UserId = user.Id
            };

            await controller.AddAsync(order);

            var orders = await controller.GetAllAsync();
            Assert.That(orders.Count, Is.EqualTo(1));
            Assert.That(orders[0].UserId, Is.EqualTo(user.Id));
            Assert.That(orders[0].Status, Is.EqualTo(Status.Pending));
        }

        [Test]
        public async Task TestGetByIdCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "Asen", Password = "123", Email = "asen@test.com" };

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Processing,
                User = user 
            };

            await controller.AddAsync(order);

            Order dbOrder = await controller.GetByIdAsync(order.Id);
            Assert.That(dbOrder, Is.Not.Null);
            Assert.That(dbOrder!.Id, Is.EqualTo(order.Id));
            Assert.That(dbOrder.Status, Is.EqualTo(Status.Processing));
        }

        [Test]
        public async Task TestDeleteCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "Petar", Password = "123", Email = "petar@test.com" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Pending,
                UserId = user.Id
            };
            await controller.AddAsync(order);

            await controller.DeleteAsync(order.Id);

            var orders = await controller.GetAllAsync();
            Assert.That(orders.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task TestDelete_ShouldDoNothing_WhenOrderDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "Maria", Password = "123", Email = "maria@test.com" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Pending,
                UserId = user.Id
            };
            await controller.AddAsync(order);

            await controller.DeleteAsync(-1);

            var orders = await controller.GetAllAsync();
            Assert.That(orders.Count, Is.EqualTo(1)); 
        }

        [Test]
        public async Task TestUpdateOrderStatusCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "Elena", Password = "123", Email = "elena@test.com" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Pending,
                UserId = user.Id
            };
            await controller.AddAsync(order);

            await controller.UpdateOrderStatus(order.Id, Status.Completed);

            Order checkOrder = await controller.GetByIdAsync(order.Id);
            Assert.That(checkOrder, Is.Not.Null);
            Assert.That(checkOrder!.Status, Is.EqualTo(Status.Completed));
        }

        [Test]
        public async Task TestUpdateOrderStatus_ShouldDoNothing_WhenOrderDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "George", Password = "123", Email = "george@test.com" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Pending,
                UserId = user.Id
            };
            await controller.AddAsync(order);

            await controller.UpdateOrderStatus(9999, Status.Cancelled);

            Order checkOrder = await controller.GetByIdAsync(order.Id);
            Assert.That(checkOrder!.Status, Is.EqualTo(Status.Pending));
        }

        [Test]
        public async Task TestGetOrdersByDateRange()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            OrderController controller = new OrderController(context);

            var user = new User { Username = "TestUser", Password = "123", Email = "test@test.com" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            DateTime tomorrow = today.AddDays(1);

            await controller.AddAsync(new Order { OrderDate = yesterday, Status = Status.Pending, UserId = user.Id });
            await controller.AddAsync(new Order { OrderDate = today, Status = Status.Pending, UserId = user.Id });
            await controller.AddAsync(new Order { OrderDate = tomorrow, Status = Status.Pending, UserId = user.Id });

            DateTime searchStart = today.AddDays(-1).AddHours(1); 
            DateTime searchEnd = today.AddHours(23); 

            List<Order> result = await controller.GetOrdersByDateRangeAsync(today.AddMinutes(-5), today.AddMinutes(5));
  
            List<Order> exactResult = await controller.GetOrdersByDateRangeAsync(today, today.AddHours(2));
            Assert.That(exactResult.Count, Is.EqualTo(1));
        }
    }
}
