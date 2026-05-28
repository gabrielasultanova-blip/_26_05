using Testove.Helpers;
using _26_05.Entities;
using _26_05.Enums;
using Controller.Business;

namespace Testove.Services
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Login_User_1()
        {
            var context = TestOnlineShopDb.CreateContext();

            User user = new User
            {
                Username = "ivan",
                Password = "123",
                Email = "ivan@gmail.com",
                Role = Role.User
            };
            context.Users.Add(user);
        
           
            await context.SaveChangesAsync();

            LogInController c = new LogInController(context);

            User? user1 = await c.Login("ivan", "123");

            Assert.That(user1 != null);
            Assert.That("ivan" == user1.Username);
        }
    }
}
