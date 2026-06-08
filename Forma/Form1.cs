using _26_05;
using _26_05.Entities;
using _26_05.Enums;
using Controller.Business;

namespace Forma
{
    public partial class Form1 : Form
    {
        UserController userController = new UserController();
        LogInController logInController = new LogInController();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.Show();

            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            var user = await logInController.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Грешно потребителско име или парола!!!");
                return;
            }

            if (user.Role == Role.Admin)
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
            }
            else
            {
                ClientForm clientForm = new ClientForm(); 
                clientForm.LoggedUser = user;
                clientForm.Show();
            }

            textBox1.Clear();
            textBox2.Clear();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
