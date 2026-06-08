using _26_05.Entities;
using _26_05.Enums;
using Controller.Business;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User = _26_05.Entities.User;

namespace Forma
{
    public partial class OrderForm : Form
    {
        OrderController orderController = new OrderController();
        OrderItemController orderItemController = new OrderItemController();
        BookController bookController = new BookController();
        UserController userController = new UserController();

        User currentUser;
        public OrderForm(User loggedUser)
        {
            InitializeComponent();
            this.currentUser = loggedUser;
        }

        private async void OrderForm_Load(object sender, EventArgs e)
        {
            await LoadUserOrdersAsync();
            LoadCartItems();
        }

        private async Task LoadUserOrdersAsync()
        {
            var myOrders = await userController.GetOrdersByUserIdAsync(currentUser.Id);

            listBox1.DataSource = null;

            listBox1.DataSource = myOrders.Select(o =>
                $"Поръчка: {o.Id}. | Дата: {o.OrderDate.ToString("dd.MM.yyyy HH:mm")} | Статус: {o.Status}"
            ).ToList();

            listBox1.Tag = myOrders;
        }

        private void LoadCartItems()
        {
            listBox2.DataSource = null;
            var cartLines = new List<string>();
            foreach (var item in ShoppingCart.Items)
            {
                cartLines.Add($"{item.Book.Title} — {item.Quantity} бр. (Ед. цена: {item.Book.Price:F2} евро)");
            }

            listBox2.DataSource = cartLines;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.LoggedUser = this.currentUser;

            form.ShowDialog();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadUserOrdersAsync();
            //LoadCartItems();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;

            if (selectedIndex == null)
            {
                MessageBox.Show("Моля, изберете продукт от количката, който да премахнете!");
                return;
            }
            ShoppingCart.Items.RemoveAt(selectedIndex);
            LoadCartItems();
            MessageBox.Show("Продуктът беше премахнат от количката.");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.Items.Count == 0)
            {
                MessageBox.Show("Количката ви е празна! Отидете в меню 'Разгледай', за да добавите книги.");
                return;
            }

            var confirmResult = MessageBox.Show("Сигурни ли сте, че искате да завършите поръчката?");
            if (confirmResult != DialogResult.Yes) return;

            Order newOrder = new Order
            {
                OrderDate = DateTime.Now,
                Status = Status.Pending,
                UserId = currentUser.Id
            };

            await orderController.AddAsync(newOrder);

            foreach (var cartItem in ShoppingCart.Items)
            {
                var dbBook = await bookController.GetByIdAsync(cartItem.BookId);

                if (dbBook == null || dbBook.Quantity < cartItem.Quantity)
                {
                    MessageBox.Show($"Грешка: Книгата вече не е налична в исканото количество! Поръчката е прекратена.");
                    return;
                }

                OrderItem newDbItem = new OrderItem
                {
                    OrderId = newOrder.Id,
                    BookId = cartItem.BookId,
                    Quantity = cartItem.Quantity
                };

                await orderItemController.AddAsync(newDbItem);

                dbBook.Quantity -= cartItem.Quantity;
                if (dbBook.Quantity == 0)
                {
                    dbBook.InStock = false;
                }

                await bookController.UpdateAsync(dbBook.Id, dbBook);
            }

            ShoppingCart.Clear();
            LoadCartItems();
            await LoadUserOrdersAsync();

            MessageBox.Show("Поръчката Ви е изпратена успешно за обработка!");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.Items == null || ShoppingCart.Items.Count == 0)
            {
                MessageBox.Show("Количката ви е празна!");
                return;
            }

            listBox2.DataSource = null;
            listBox2.DisplayMember = "";

            listBox2.DataSource = ShoppingCart.Items.Select(item =>
                $"{item.Book.Title} - {item.Book.Author.FirstName} {item.Book.Author.LastName} | {item.Book.Price:F2} euro"
            ).ToList();

            decimal totalSum = ShoppingCart.Items.Sum(item => item.Quantity * item.Book.Price);
            label3.Text = $"Обща сума: {totalSum:F2} euro";
        }
    }
}
