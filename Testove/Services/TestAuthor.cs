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
    public class TestAuthor
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            AuthorController controller = new AuthorController(context);

            Author author = new Author
            {
                FirstName = "Ivan",
                LastName = "Vazov",
                Age = 70,
                Nationality = "Bulgarian"
            };

            await controller.AddAsync(author);

            var authors = context.Authors.ToList();
            Assert.That(authors.Count, Is.EqualTo(1));
            Assert.That(authors[0].FirstName, Is.EqualTo("Ivan"));
            Assert.That(authors[0].LastName, Is.EqualTo("Vazov"));
            Assert.That(authors[0].Age, Is.EqualTo(70));
            Assert.That(authors[0].Nationality, Is.EqualTo("Bulgarian"));
        }

        [Test]
        public async Task TestGetAllCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            AuthorController controller = new AuthorController(context);
            Author author1 = new Author
            {
                FirstName = "Ivan",
                LastName = "Vazov",
                Age = 70,
                Nationality = "Bulgarian"
            };
            await controller.AddAsync(author1);
            Author author2 = new Author
            {
                FirstName = "Elin",
                LastName = "Pelin",
                Age = 70,
                Nationality = "Bulgarian"
            };
            await controller.AddAsync(author2);

            var authors = await controller.GetAllAsync();

            Assert.That(authors.Count, Is.EqualTo(2));
            Assert.That(authors, Is.Not.Empty);
        }

        [Test]
        public async Task TestUpdateCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            AuthorController controller = new AuthorController(context);
            Author author1 = new Author
            {
                FirstName = "Ivan",
                LastName = "Vazov",
                Age = 70,
                Nationality = "Bulgarian"
            };
            await controller.AddAsync(author1);

            var updatedAuthor = new Author
            {
                FirstName = "NewIvan",
                LastName = "NewVazov",
                Age = 70,
                Nationality = "NewBulgarian"
            };

            await controller.UpdateAsync(1, updatedAuthor);
            List<Author> authors = await controller.GetAllAsync();
            Assert.That(context.Authors.Count(), Is.EqualTo(1));
            Assert.That(authors[0].FirstName, Is.EqualTo("NewIvan"));
        }

        [Test]
        public async Task TestDeleteCorrect()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            AuthorController controller = new AuthorController(context);
            Author author1 = new Author
            {
                FirstName = "Ivan",
                LastName = "Vazov",
                Age = 70,
                Nationality = "Bulgarian"
            };
            await controller.AddAsync(author1);
            await controller.DeleteAsync(1);
            var authors = context.Authors.ToList();
            Assert.That(authors.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestUpdateWhenAuthorDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            AuthorController controller = new AuthorController(context);

            var updatedData = new Author { FirstName = "Ghost", LastName = "Writer" };
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await controller.UpdateAsync(999, updatedData)
            );
        }

        [Test]
        public async Task TestDeleteShouldDoNothingWhenAuthorDoesNotExist()
        {
            OnlineShop_Db context = TestOnlineShopDb.CreateContext();
            AuthorController controller = new AuthorController(context);

            Author author = new Author
            {
                FirstName = "Ivan",
                LastName = "Vazov",
                Age = 70,
                Nationality = "Bulgarian" 
            };
            await controller.AddAsync(author);

            await controller.DeleteAsync(-1);

            var authors = context.Authors.ToList();
            Assert.That(authors.Count, Is.EqualTo(1));
            Assert.That(authors[0].FirstName, Is.EqualTo("Ivan"));
        }
    }
}


