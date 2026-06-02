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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthorsForm form = new AuthorsForm();

            form.ShowDialog();
            this.Hide();
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm();

            form.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PublisherForm form = new PublisherForm();

            form.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsersOrders form = new UsersOrders();

            form.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();

            form.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            form.ShowDialog();
            this.Hide();
        }
    }
}
