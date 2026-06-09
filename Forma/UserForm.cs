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
    public partial class UserForm : Form
    {
        UserController controller = new UserController();
        public UserForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();

            form.Show();
            this.Close();
        }

        private async void AdminUsersForm_Load(object sender, EventArgs e)
        {
            await RefreshDeleteListBoxAsync();
        }

        private async Task RefreshDeleteListBoxAsync()
        {
            var users = await controller.GetAllAsync();

            listBox4.DataSource = null;

            listBox4.DataSource = users.Select(u =>
                $"Потребител: {u.Id}. | Потребителско име: {u.Username} | Имейл: {u.Email}"
            ).ToList();
            listBox4.Tag = users;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете потребител от списъка, когото искате да изтриете!");
                return;
            }

            string selectedItemText = listBox4.SelectedItem.ToString();
            string idPart = selectedItemText.Split('|')[0].Trim();
            int userId = int.Parse(idPart);

            var allUsers = await controller.GetAllAsync();
            var userToCheck = allUsers.Find(u => u.Id == userId);

            DialogResult cascadeResult = MessageBox.Show(
     $"Внимание! Потребителят '{userToCheck.Username}' има {userToCheck.Orders.Count} направени поръчки.\n" +
     "Ако го изтриете, всички негови поръчки и хронология също ще бъдат изтрити от базата данни каскадно!\n\n" +
     "Сигурни ли сте, че искате да продължите?",
     "Потвърждение",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Warning);

            if (cascadeResult != DialogResult.Yes)
            {
                return;
            }
            DialogResult result = MessageBox.Show(
      $"Наистина ли искате да изтриете потребител с ID {userId}?",
      "Потвърждение",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            await controller.DeleteAsync(userId);
            MessageBox.Show("Потребителят беше изтрит успешно от системата!");
            await RefreshDeleteListBoxAsync();



        }

        private async void btnRefreshDeleteList_Click(object sender, EventArgs e)
        {
            await RefreshDeleteListBoxAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            var adminList = await controller.GetAllAdminsAsync();
            foreach (var admin in adminList)
            {
                listBox2.Items.Add($"ID: {admin.Id} | Админ: {admin.Username} ({admin.Email})");
            }

            var userList = await controller.GetAllUsersAsync();
            foreach (var user in userList)
            {
                listBox3.Items.Add($"ID: {user.Id} | Потребител: {user.Username} ({user.Email})");
            }

            if (adminList.Count == 0 && userList.Count == 0)
            {
                MessageBox.Show("Няма регистрирани потребители в системата.");
            }

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await RefreshDeleteListBoxAsync();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
