using _26_05.Entities;
using _26_05.Enums;
using Controller.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma
{
    public partial class OrderForm : Form
    {
        OrderController orderController = new OrderController();
        OrderItemController orderItemController = new OrderItemController();
        BookController bookController = new BookController();
        UserController userController = new UserController();
        User currentUser = new User();
        public OrderForm()
        {
            InitializeComponent();
            listBox1.DisplayMember = "Id";
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
            listBox1.DataSource = myOrders;
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

            form.ShowDialog();
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете поръчка от списъка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Order selectedOrder = (Order)listBox1.SelectedItem;
            var fullOrder = await orderController.GetByIdAsync(selectedOrder.Id);
            var allOrderItems = await orderItemController.GetAllAsync();

            string details = $"Поръчка номер: {fullOrder.Id}\nДата: {fullOrder.OrderDate}\nСтатус: {fullOrder.Status}\nПродукти:\n";
            decimal totalOrderPrice = 0;

            foreach (var item in allOrderItems)
            {
                if (item.OrderId == fullOrder.Id)
                {
                    var book = await bookController.GetByIdAsync(item.BookId);
                    if (book != null)
                    {
                        decimal itemTotal = book.Price * item.Quantity;
                        totalOrderPrice += itemTotal;
                        details += $"- {book.Title}: {item.Quantity} бр. x {book.Price:F2} лв. = {itemTotal:F2} лв.\n";
                    }
                }
            }

            details += $"\nОбща сума: {totalOrderPrice:F2} лв.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;

            if (selectedIndex == null)
            {
                MessageBox.Show("Моля, изберете продукт от количката, който да премахнете!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShoppingCart.Items.RemoveAt(selectedIndex);
            LoadCartItems();
            MessageBox.Show("Продуктът беше премахнат от количката.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.Items.Count == 0)
            {
                MessageBox.Show("Количката ви е празна! Отидете в меню 'Разгледай', за да добавите книги.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Сигурни ли сте, че искате да завършите поръчката?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    cartItem.OrderId = newOrder.Id;
                    var dbBook = await bookController.GetByIdAsync(cartItem.BookId);

                    if (dbBook == null || dbBook.Quantity < cartItem.Quantity)
                    {
                        MessageBox.Show($"Грешка: Книгата '{cartItem.Book.Title}' вече не е налична в исканото количество! Поръчката е прекратена.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cartItem.Book = null;
                    await orderItemController.AddAsync(cartItem);

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

                MessageBox.Show("Поръчката Ви е изпратена успешно за обработка!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
