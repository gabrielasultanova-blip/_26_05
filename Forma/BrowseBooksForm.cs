using _26_05.Entities;
using Controller.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma
{
    public partial class BrowseBooksForm : Form
    {
        BookController bookController = new BookController();
        User currentUser = new User();
        List<Book> displayedBooks = new List<Book>();

        public BrowseBooksForm(User loggedUser)
        {
            InitializeComponent();
            currentUser = loggedUser;

            radioButton1.CheckedChanged += rbAuthor_CheckedChanged;
            radioButton2.CheckedChanged += rbPublisher_CheckedChanged;
            radioButton3.CheckedChanged += rbGenre_CheckedChanged;
            radioButton4.CheckedChanged += rbTitle_CheckedChanged;
            radioButton5.CheckedChanged += rbPrice_CheckedChanged;
            radioButton6.CheckedChanged += rbInStock_CheckedChanged;
        }

        private async Task RefreshListAsync()
        {
            displayedBooks = await bookController.GetAllAsync();
            listBox1.DataSource = null;
            listBox1.DataSource = displayedBooks;
        }

        private async Task LoadAllBooksAsync()
        {
            displayedBooks = await bookController.GetAllAsync();
            UpdateListBox();
        }
        private void UpdateListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = displayedBooks;
        }

        private async void BrowseBooksForm_Load(object sender, EventArgs e)
        {
            await LoadAllBooksAsync();
            HideAllFilterControls(); 
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.LoggedUser = this.currentUser; 

            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете книга от списъка!");
                return;
            }

            Book selectedBook = (Book)listBox1.SelectedItem;
            if (!selectedBook.InStock || selectedBook.Quantity <= 0)
            {
                MessageBox.Show("Съжаляваме, тази книга в момента не е в наличност!");
                return;
            }

            int inputQuantity = (int)numericUpDown1.Value;
            if (inputQuantity > selectedBook.Quantity)
            {
                MessageBox.Show($"Няма достатъчно наличност! Максимално количество в склада: {selectedBook.Quantity} бр.");
                return;
            }

            var existingItem = ShoppingCart.Items.Find(oi => oi.BookId == selectedBook.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity + inputQuantity > selectedBook.Quantity)
                {
                    MessageBox.Show("Общото количество в количката надвишава наличността на книгата!");
                    return;
                }
                existingItem.Quantity += inputQuantity;
            }
            else
            {
                ShoppingCart.Items.Add(new OrderItem
                {
                    BookId = selectedBook.Id,
                    Book = selectedBook, 
                    Quantity = inputQuantity
                });
            }

            MessageBox.Show($"Книгата '{selectedBook.Title}' беше добавена в количката!");
            numericUpDown1.Value = 1;
            await RefreshListAsync();
        }

        private void rbAuthor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                HideAllFilterControls();
                label1.Text = "Име на автор:";
                label1.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "";
                button1.Visible = true;
            }
        }

        private void rbPublisher_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                HideAllFilterControls();
                label1.Text = "Издателство:";
                label1.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "";
                button1.Visible = true;
            }
        }

        private void rbGenre_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                HideAllFilterControls();
                label1.Text = "Жанр:";
                label1.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "";
                button1.Visible = true;
            }
        }

        private void rbTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                HideAllFilterControls();
                label1.Text = "Заглавие:";
                label1.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "";
                button1.Visible = true;
            }
        }

        private void rbPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                HideAllFilterControls();
                label1.Text = "Ценови диапазон:";
                label1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox2.Text = "0";
                textBox3.Text = "100";
                button1.Visible = true;
            }
        }

        private void rbInStock_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                HideAllFilterControls();
                label1.Text = "Ще се покажат само наличните книги.";
                label1.Visible = true;
                button1.Visible = true;
            }
        }

        private void HideAllFilterControls()
        {
            label1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Book selectedBook)
            {
                if (selectedBook.Quantity > 0 && selectedBook.InStock)
                {
                    numericUpDown1.Minimum = 1;
                    numericUpDown1.Maximum = selectedBook.Quantity;
                    numericUpDown1.Value = 1;
                    numericUpDown1.Enabled = true;
                }
                else
                {
                    numericUpDown1.Minimum = 0;
                    numericUpDown1.Maximum = 0;
                    numericUpDown1.Value = 0;
                    numericUpDown1.Enabled = false; 
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Моля, въведете текст за търсене!");
                    return;
                }
            }

            string input = textBox1.Text.Trim();

            if (radioButton1.Checked)
            {
                displayedBooks = await bookController.GetBooksByAuthorsNameAsync(input);
            }
            else if (radioButton2.Checked)
            {
                displayedBooks = await bookController.GetBooksByPublisherAsync(input);
            }
            else if (radioButton3.Checked)
            {
                displayedBooks = await bookController.GetBooksByGenreAsync(input);
            }
            else if (radioButton4.Checked)
            {
                var book = await bookController.GetBookByTitleAsync(input);
                displayedBooks.Clear();
                if (book != null) displayedBooks.Add(book);
            }

            else if (radioButton5.Checked)
            {
                int min = int.Parse(textBox2.Text.Trim());
                int max = int.Parse(textBox3.Text.Trim());

                if (min > max)
                {
                    MessageBox.Show("Минималната цена не може да бъде по-голяма от максималната!");
                    return;
                }

                displayedBooks = await bookController.GetBooksByPriceRangeAsync(min, max);
            }
            else if (radioButton6.Checked)
            {
                displayedBooks = await bookController.IsInStockAsync();
            }
            if (displayedBooks == null || displayedBooks.Count == 0)
            {
                MessageBox.Show("Няма намерени книги по избраните критерии!");
                displayedBooks = await bookController.GetAllAsync();
            }

            listBox1.DataSource = null;
            listBox1.DataSource = displayedBooks;
        }
    }
    
}
