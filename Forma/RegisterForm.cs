using Business.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _26_05.Entities;
using Business.Controller;
using _26_05;
using _26_05.Enums;

namespace Forma
{
    public partial class RegisterForm : Form
    {
        LogInController logInController = new LogInController();
        UserController userController = new UserController();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = textBox1.Text,
                Email = textBox2.Text,
                Password = textBox3.Text,
                Role = Role.User
            };

            await userController.AddUserAsync(user);

            MessageBox.Show("Успешна регистрация!!!");

            Form1 form1 = new Form1();
            form1.Show();

            this.Close();
        }
    }
}
