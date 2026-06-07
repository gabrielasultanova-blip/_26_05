using _26_05.Entities;
using Controller.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma
{
    public partial class BookForm : Form
    {
        BookController controller = new BookController();
        AuthorController authorController = new AuthorController();
        PublisherController publisherController = new PublisherController();

        public BookForm()
        {
            InitializeComponent();
        }

        private async Task LoadComboBoxDataAsync()
        {
            var authors = await authorController.GetAllAsync();
            var authorsWithFullNames = authors.Select(a => new
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}".Trim()
            }).ToList();

            comboBox1.DataSource = new BindingSource(authorsWithFullNames, null);
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "Id";

            comboBox3.DataSource = new BindingSource(authorsWithFullNames, null);
            comboBox3.DisplayMember = "FullName";
            comboBox3.ValueMember = "Id";

            var publishers = await publisherController.GetAllAsync();

            comboBox2.DataSource = new BindingSource(publishers, null);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";

            comboBox4.DataSource = new BindingSource(publishers, null);
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "Id";
        }



        private async Task RefreshDeleteListBoxAsync()
        {
            listBox1.Items.Clear();
            var books = await controller.GetAllAsync();

            foreach (var book in books)
            {
                listBox1.Items.Add($"{book.Id} | {book.Title} - {book.Author.FirstName} {book.Author.LastName} - {Math.Round(book.Price, 2)} euro (кол: {book.Quantity})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();

            form.Show();
            this.Close();
        }

        private void ClearTexBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();

            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;
            if (comboBox3.Items.Count > 0) comboBox3.SelectedIndex = 0;
            if (comboBox4.Items.Count > 0) comboBox4.SelectedIndex = 0;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Заглавието и Жанрът са задължителни полета!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price = decimal.Parse(textBox3.Text);
            if (price < 0.01m || price > 1000m || price == null)
            {
                MessageBox.Show("Моля, въведете валидна цена между 0.01 и 1000!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pages = int.Parse(textBox4.Text);
            if (pages < 1 || pages > 10000 || pages == null)
            {
                MessageBox.Show("Страниците трябва да бъдат цяло число между 1 и 10 000!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = int.Parse(textBox5.Text);
            if (quantity < 0 || quantity > 1000 || quantity == null)
            {
                MessageBox.Show("Количеството трябва да бъде между 0 и 1000!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете валиден Автор и Издател от списъците!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int authorId = (int)comboBox1.SelectedValue;
            int publisherId = (int)comboBox2.SelectedValue;

            DateOnly publishedOn = DateOnly.Parse(textBox7.Text);
            if (publishedOn == null)
            {
                MessageBox.Show("Моля, въведете валидна дата в формат (ГГГГ-ММ-ДД)!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool inStock = quantity > 0;

            Book newBook = new Book
            {
                Title = textBox1.Text.Trim(),
                Genre = textBox2.Text.Trim(),
                Price = price,
                Pages = pages,
                Quantity = quantity,
                InStock = inStock,
                PublishedOn = publishedOn,
                AuthorId = authorId,
                PublisherId = publisherId
            };

            await controller.AddAsync(newBook);
            MessageBox.Show("Книгата беше добавена успешно!");
            await RefreshDeleteListBoxAsync();
            await LoadComboBoxDataAsync();
            ClearTexBoxes();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(textBox6.Text);
            if (bookId <= 0)
            {
                MessageBox.Show("Моля, въведете валидно ID на книга за редакция!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingBook = controller.GetByIdAsync(bookId);
            if (existingBook == null)
            {
                MessageBox.Show("Не е намерена книга с такова ID!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox10.Text) || string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Полетата Заглавие и Жанр не могат да бъдат празни!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price = decimal.Parse(textBox12.Text);
            if (price < 0.01m || price > 1000m || price == null)
            {
                MessageBox.Show("Моля, въведете валидна цена между 0.01 и 1000!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pages = int.Parse(textBox13.Text);
            if (pages < 1 || pages > 10000 || pages == null)
            {
                MessageBox.Show("Страниците трябва да бъдат цяло число между 1 и 10 000!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = int.Parse(textBox14.Text);
            if (quantity < 0 || quantity > 1000 || quantity == null)
            {
                MessageBox.Show("Количеството трябва да бъде между 0 и 1000!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool inStock = quantity > 0;
            if (quantity == 0)
            {
                MessageBox.Show("Книгата не може да бъде маркирана 'В наличност', ако количеството ѝ е 0. Автоматично ще бъде коригирана.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                inStock = false;
            }

            int authorId = (int)comboBox3.SelectedValue;
            int publisherId = (int)comboBox4.SelectedValue;

            Book updatedBook = new Book
            {
                Title = textBox10.Text.Trim(),
                Genre = textBox11.Text.Trim(),
                Price = price,
                Pages = pages,
                Quantity = quantity,
                InStock = inStock,
                PublishedOn = DateOnly.Parse(textBox15.Text),
                AuthorId = authorId,
                PublisherId = publisherId
            };

            await controller.UpdateAsync(bookId, updatedBook);
            MessageBox.Show("Книгата беше редактирана успешно!");
            await RefreshDeleteListBoxAsync();
            await LoadComboBoxDataAsync();
            ClearTexBoxes();
        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете книга от списъка, която искате да изтриете!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItemText = listBox1.SelectedItem.ToString();
            string idPart = selectedItemText.Split('|')[0].Trim();
            int bookId = int.Parse(idPart);

            var bookToCheck = await controller.GetByIdAsync(bookId);
            if (bookToCheck != null && bookToCheck.OrderItems != null && bookToCheck.OrderItems.Count > 0)
            {
                MessageBox.Show($"Книгата '{bookToCheck.Title}' не може да бъде изтрита, защото участва в {bookToCheck.OrderItems.Count} направени поръчки!",
                                "Забранено изтриване", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Наистина ли искате да изтриете книгата с ID {bookId}?",
                "Потвърждение за изтриване",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await controller.DeleteAsync(bookId);
                    MessageBox.Show("Книгата беше изтрита успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefreshDeleteListBoxAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Грешка при изтриване: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            await RefreshDeleteListBoxAsync();
            await LoadComboBoxDataAsync();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            var inStockBooks = await controller.IsInStockAsync();
            foreach (var book in inStockBooks)
            {
                listBox2.Items.Add($"{book.Title} - {book.Author} (Налични: {book.Quantity} бр.) - {book.Price:C2}");
            }

            var notInStockBooks = await controller.IsNotInStockAsync();
            foreach (var book in notInStockBooks)
            {
                listBox3.Items.Add($"{book.Title} - {book.Author} (Няма в наличност)");
            }

            if (inStockBooks.Count == 0 && notInStockBooks.Count == 0)
            {
                MessageBox.Show("Няма регистрирани книги в базата данни.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BookForm_Load(object sender, EventArgs e)
        {
            await LoadComboBoxDataAsync();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await RefreshDeleteListBoxAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
