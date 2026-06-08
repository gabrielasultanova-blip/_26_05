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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forma
{
    public partial class UsersOrders : Form
    {
        OrderController controller = new OrderController();
        public UsersOrders()
        {
            InitializeComponent();
        }

        private async void UsersOrders_Load(object sender, EventArgs e)
        {
            await LoadAllOrdersAsync();
        }

        private async Task LoadAllOrdersAsync()
        {
            listBox1.Items.Clear();
            var orders = await controller.GetAllAsync();

            foreach (var order in orders)
            {
                string username = order.User != null ? order.User.Username : $"Потребител ID: {order.UserId}";
                listBox1.Items.Add($"{order.Id} | Дата: {order.OrderDate:yyyy-MM-dd HH:mm} | Клиент: {username} | Статус: {order.Status}");
            }

            if (orders.Count == 0)
            {
                MessageBox.Show("Няма намерени поръчки в системата.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();

            form.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

        }



        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadAllOrdersAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Началната дата не може да бъде след крайната дата!");
                return;
            }

            var filteredOrders = await controller.GetOrdersByDateRangeAsync(startDate, endDate);

            foreach (var order in filteredOrders)
            {
                listBox1.Items.Add($"{order.Id} | Дата: {order.OrderDate:yyyy-MM-dd HH:mm} | Потребител ID: {order.UserId} | Статус: {order.Status}");
            }

            if (filteredOrders.Count == 0)
            {
                MessageBox.Show("Няма намерени поръчки в този времеви диапазон.");
            }

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Моля, въведете ID на поръчка в текстовото поле!");
                return;
            }

            int orderId = int.Parse(textBox1.Text.Trim());

            var order = await controller.GetByIdAsync(orderId);

            if (order == null)
            {
                MessageBox.Show($"Не е намерена поръчка с ID: {orderId}!");
                return;
            }

            string clientUsername = "";
            string clientEmail = "";

            if (order.User != null)
            {
                clientUsername = order.User.Username;
                clientEmail = order.User.Email;
            }
            else
            {
                clientUsername = "Няма информация";
                clientEmail = "Няма информация";
            }

            int totalItemsCount = order.OrderItems != null ? order.OrderItems.Count : 0;

            string orderDetails = $"=== ДЕТАЙЛИ ЗА ПОРЪЧКА № {order.Id} ===\n\n" +
                                  $" Направена на: {order.OrderDate:dd.MM.yyyy г. в HH:mm ч.}\n" +
                                  $" Статус: {order.Status}\n\n" +
                                  $" --- ДАННИ ЗА КЛИЕНТА ---\n" +
                                  $" Потребителско име: {clientUsername}\n" +
                                  $" Е-мейл адрес: {clientEmail}\n" +
                                  $" Потребител ID: {order.UserId}\n\n" +
                                  $" --- СЪДЪРЖАНИЕ ---\n" +
                                  $" Брой различни артикули: {totalItemsCount} бр.\n" +
                                  $"=====================================";

            richTextBox1.Text = orderDetails;
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Моля, въведете ID на поръчка!");
                return;
            }

            int orderId = int.Parse(textBox2.Text.Trim());

            _26_05.Enums.Status newStatus = _26_05.Enums.Status.Pending;

            if (radioButton1.Checked)
            {
                newStatus = _26_05.Enums.Status.Processing;
            }
            else if (radioButton2.Checked)
            {
                newStatus = _26_05.Enums.Status.Completed;
            }
            else if (radioButton3.Checked)
            {
                newStatus = _26_05.Enums.Status.Shipped;
            }
            else if (radioButton4.Checked)
            {
                newStatus = _26_05.Enums.Status.Cancelled;
            }

            await controller.UpdateOrderStatus(orderId, newStatus);

            MessageBox.Show($"Статусът на поръчка: {orderId}. беше сменен на {newStatus}!");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

