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

            context.Users.Add(new User
            {
                Username = "ivan",
                Password = "123",
                Role = Role.User
            });

            await context.SaveChangesAsync();

            LogInController c = new LogInController();

            User? user = await c.Login("ivan", "123");

            Assert.IsNotNull(user);
            Assert.AreEqual("ivan", user.Username);
        }
    }
}
