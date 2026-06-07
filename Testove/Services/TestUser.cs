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
    public class TestUser
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddAndGetAllCorrect()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            User user = new User
            {
                Username = "Krisi",
                Password = "SecurePassword123",
                Email = "krisi@test.com",
                Role = Role.User
            };

            await controller.AddAsync(user);

            var users = await controller.GetAllAsync();

            Assert.That(users.Count, Is.EqualTo(2));
            Assert.That(users.Any(u => u.Username == "Krisi"), Is.True);
        }

        [Test]
        public async Task TestUpdateCorrect()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            User original = new User
            {
                Username = "OldName",
                Password = "Pass1",
                Email = "old@test.com",
                Role = Role.User
            };
            await controller.AddAsync(original);

            User updatedData = new User
            {
                Username = "NewName",
                Password = "NewPassword",
                Email = "new@test.com",
                Role = Role.Admin
            };

            await controller.UpdateAsync(original.Id, updatedData);

            var users = await controller.GetAllAsync();
            var checkUser = users.FirstOrDefault(u => u.Id == original.Id);

            Assert.That(checkUser, Is.Not.Null);
            Assert.That(checkUser!.Username, Is.EqualTo("NewName"));
            Assert.That(checkUser.Role, Is.EqualTo(Role.Admin));
        }

        [Test]
        public async Task TestDeleteCorrect()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            User user = new User
            {
                Username = "DeleteMe",
                Password = "123",
                Email = "del@test.com",
                Role = Role.User
            };
            await controller.AddAsync(user);

            await controller.DeleteAsync(user.Id);

            var users = await controller.GetAllAsync();

            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.Any(u => u.Username == "DeleteMe"), Is.False);
        }


        [Test]
        public async Task TestDelete_ShouldDoNothing_WhenUserDoesNotExist()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            User user = new User
            {
                Username = "SafeUser",
                Password = "123",
                Email = "safe@test.com",
                Role = Role.User
            };
            await controller.AddAsync(user);

            await controller.DeleteAsync(9999);

            var users = await controller.GetAllAsync();

            Assert.That(users.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TestGetOrdersByUserId()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            User user = new User { Username = "Buyer", Password = "123", Email = "buyer@test.com", Role = Role.User };
            await controller.AddAsync(user);

            Order order = new Order { OrderDate = DateTime.Now, Status = Status.Pending, UserId = user.Id };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            List<Order> result = await controller.GetOrdersByUserIdAsync(user.Id);

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].UserId, Is.EqualTo(user.Id));
        }

        [Test]
        public async Task TestGetAllAdmins()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            await controller.AddAsync(new User { Username = "Admin1", Password = "1", Email = "a1@test.com", Role = Role.Admin });
            await controller.AddAsync(new User { Username = "User1", Password = "1", Email = "u1@test.com", Role = Role.User });
            await controller.AddAsync(new User { Username = "Admin2", Password = "1", Email = "a2@test.com", Role = Role.Admin });

            List<User> admins = await controller.GetAllAdminsAsync();

            Assert.That(admins.Count, Is.EqualTo(3));
            Assert.That(admins.Any(u => u.Role == Role.User), Is.False);
        }

        [Test]
        public async Task TestGetAllUsers()
        {
            using var context = TestOnlineShopDb.CreateContext();
            UserController controller = new UserController(context);

            await controller.AddAsync(new User { Username = "Admin1", Password = "1", Email = "a1@test.com", Role = Role.Admin });
            await controller.AddAsync(new User { Username = "User1", Password = "1", Email = "u1@test.com", Role = Role.User });
            await controller.AddAsync(new User { Username = "User2", Password = "1", Email = "u2@test.com", Role = Role.User });

            List<User> users = await controller.GetAllUsersAsync();

            Assert.That(users.Count, Is.EqualTo(2));
            Assert.That(users.Any(u => u.Role == Role.Admin), Is.False);
        }
    }
}
