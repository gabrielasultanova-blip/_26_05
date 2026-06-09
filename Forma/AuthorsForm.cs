using _26_05.Entities;
using Azure.Identity;
using Controller.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma
{
    public partial class AuthorsForm : Form
    {
        AuthorController controller = new AuthorController();
        public AuthorsForm()
        {
            InitializeComponent();
        }

        private async Task RefreshDeleteListAsync()
        {
            listBox1.Items.Clear();
            var authors = await controller.GetAllAsync();

            foreach (var author in authors)
            {
                listBox1.Items.Add($"{author.Id} | {author.FirstName} {author.LastName} {author.Age} год. - {author.Nationality}");
            }
        }

        private async void AdminAuthorsForm_Load(object sender, EventArgs e)
        {
            await RefreshDeleteListAsync();
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
            textBox8.Clear();
            textBox9.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Всички полета (Име, Фамилия, Националност) са задължителни!");
                return;
            }

            if (textBox1.Text.Length > 50 || textBox2.Text.Length > 50 || textBox4.Text.Length > 50)
            {
                MessageBox.Show("Полетата не могат да съдържат повече от 50 символа!");
                return;
            }

            int age = int.Parse(textBox3.Text);
            if (age < 18 || age > 120)
            {
                MessageBox.Show("Въведете валидна възраст за автора между 18 and 120 години!");
                return;
            }
            if (textBox3.Text == " ")
            {
                MessageBox.Show("Въведете възраст за автора!");
                return;
            }

            Author newAuthor = new Author
            {
                FirstName = textBox1.Text.Trim(),
                LastName = textBox2.Text.Trim(),
                Age = age,
                Nationality = textBox4.Text.Trim()
            };

            await controller.AddAsync(newAuthor);

            MessageBox.Show("Авторът беше добавен успешно!");
            ClearTexBoxes();
            await RefreshDeleteListAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int authorId = int.Parse(textBox5.Text);
            if (authorId <= 0)
            {
                MessageBox.Show("Моля, въведете валидно ID на автор за редакция!");
                return;
            }

            var allAuthors = await controller.GetAllAsync();
            var existingAuthor = allAuthors.Find(a => a.Id == authorId);

            if (existingAuthor == null)
            {
                MessageBox.Show("Не е намерен автор с такова ID!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Полетата не могат да бъдат празни!");
                return;
            }

            if (textBox6.Text.Length > 50 || textBox7.Text.Length > 50 || textBox9.Text.Length > 50)
            {
                MessageBox.Show("Полетата не могат да съдържат повече от 50 символа!");
                return;
            }

            int age = int.Parse(textBox8.Text);
            if (age < 18 || age > 120)
            {
                MessageBox.Show("Възрастта трябва да бъде цяло число между 18 и 120!");
                return;
            }
            if (textBox8.Text == " ")
            {
                MessageBox.Show("Въведете възраст за автора!");
                return;
            }

            Author updatedAuthor = new Author
            {
                FirstName = textBox6.Text.Trim(),
                LastName = textBox7.Text.Trim(),
                Age = age,
                Nationality = textBox9.Text.Trim()
            };

            await controller.UpdateAsync(authorId, updatedAuthor);

            MessageBox.Show("Авторът беше редактиран успешно!");
            ClearTexBoxes();
            await RefreshDeleteListAsync();
        }

        private async void button5_Click(object sender, EventArgs e)
        {

        }

        private async void btnRefreshDeleteList_Click(object sender, EventArgs e)
        {
            await RefreshDeleteListAsync();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете автор от списъка, когото искате да изтриете!");
                return;
            }

            string selectedItemText = listBox1.SelectedItem.ToString();
            string idPart = selectedItemText.Split('|')[0].Trim();
            int authorId = int.Parse(idPart);

            var allAuthors = await controller.GetAllAsync();
            var authorToCheck = allAuthors.Find(a => a.Id == authorId);

            if (authorToCheck != null && authorToCheck.Books != null && authorToCheck.Books.Count > 0)
            {
                DialogResult cascadeResult = MessageBox.Show(
    $"Внимание! Авторът '{authorToCheck.FirstName} {authorToCheck.LastName}' има {authorToCheck.Books.Count} регистрирани книги.\n" +
    "Ако го изтриете, всички негови книги СЪЩО ще бъдат изтрити автоматично от магазина!\n\n" +
    "Сигурни ли сте, че искате да продължите?",
    "Потвърждение",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

                if (cascadeResult != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"Наистина ли искате да изтриете автора с ID {authorId}?", "Потвърждение",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;
            }

            await controller.DeleteAsync(authorId);
            MessageBox.Show("Авторът беше изтрит успешно!", "Успех");
            await RefreshDeleteListAsync();
        }

        private async void button6_Click(object sender, EventArgs e)
        {

        }

        private async void button6_Click_1(object sender, EventArgs e)
        {
            await RefreshDeleteListAsync();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
