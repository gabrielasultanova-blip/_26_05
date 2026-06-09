using _26_05.Entities;
using _26_05.Enums;
using Controller.Business;

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

            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Моля попълнете всички полета!!!");
                return;
            }

            await userController.AddAsync(user);

            MessageBox.Show("Успешна регистрация!!!");

            Form1 form1 = new Form1();
            form1.Show();

            this.Close();
        }
    }
}
