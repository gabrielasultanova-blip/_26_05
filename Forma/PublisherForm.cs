using _26_05.Entities;
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
    public partial class PublisherForm : Form
    {
        PublisherController controller = new PublisherController();
        public PublisherForm()
        {
            InitializeComponent();
        }

        private async void AdminPublishersForm_Load(object sender, EventArgs e)
        {
            await RefreshDeleteListBoxAsync();
        }

        private async Task RefreshDeleteListBoxAsync()
        {
            listBox1.Items.Clear();
            var publishers = await controller.GetAllAsync();

            foreach (var publisher in publishers)
            {
                listBox1.Items.Add($"{publisher.Id} | {publisher.Name} - {publisher.Country}");
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
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Името на издателството и Държавата са задължителни полета!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text.Length > 100)
            {
                MessageBox.Show("Името на издателството не може да бъде по-дълго от 100 символа!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Length > 50)
            {
                MessageBox.Show("Името на държавата не може да бъде по-дълго от 50 символа!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Publisher newPublisher = new Publisher
            {
                Name = textBox1.Text.Trim(),
                Country = textBox2.Text.Trim()
            };

            await controller.AddAsync(newPublisher);

            MessageBox.Show("Издателството беше добавено успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTexBoxes();
            await RefreshDeleteListBoxAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int publisherId = int.Parse(textBox3.Text);
            if (publisherId <= 0)
            {
                MessageBox.Show("Моля, въведете валидно ID на издателство за редакция!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var allPublishers = await controller.GetAllAsync();
            var existingPublisher = allPublishers.Find(p => p.Id == publisherId);

            if (existingPublisher == null)
            {
                MessageBox.Show("Не е намерено издателство с такова ID!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Новото име и държава не могат да бъдат празни!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox4.Text.Length > 100 || textBox5.Text.Length > 50)
            {
                MessageBox.Show("Моля, съобразете се с ограниченията за дължина (Име до 100 симв., Държава до 50 симв.)!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Publisher updatedPublisher = new Publisher
            {
                Name = textBox4.Text.Trim(),
                Country = textBox5.Text.Trim()
            };

            await controller.UpdateAsync(publisherId, updatedPublisher);

            MessageBox.Show("Издателството беше редактирано успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTexBoxes();
            await RefreshDeleteListBoxAsync();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете издателство от списъка, което искате да изтриете!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItemText = listBox1.SelectedItem.ToString();
            string idPart = selectedItemText.Split('|')[0].Trim();
            int publisherId = int.Parse(idPart);

            var allPublishers = await controller.GetAllAsync();
            var publisherToCheck = allPublishers.Find(p => p.Id == publisherId);

            if (publisherToCheck != null && publisherToCheck.Books != null && publisherToCheck.Books.Count > 0)
            {
                DialogResult cascadeResult = MessageBox.Show(
                    $"Внимание! Издателство '{publisherToCheck.Name}' има {publisherToCheck.Books.Count} регистрирани книги.\n" +
                    "Ако го изтриете, всички негови книги СЪЩО ще бъдат изтрити автоматично от базата данни!\n\n" +
                    "Сигурни ли сте, че искате да продължите?",
                    "Критично предупреждение (Каскадно триене)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (cascadeResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"Наистина ли искате да изтриете издателството с ID {publisherId}?",
                    "Потвърждение за изтриване",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;
            }

            await controller.DeleteAsync(publisherId);
            MessageBox.Show("Издателството беше изтрито успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await RefreshDeleteListBoxAsync();

        }

        private async void btnRefreshDeleteList_Click(object sender, EventArgs e)
        {
            await RefreshDeleteListBoxAsync();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

                var publishers = await controller.GetAllAsync();

                if (publishers == null || publishers.Count == 0)
                {
                    MessageBox.Show("Няма намерени издателства в базата данни.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var publisher in publishers)
                {
                    string displayLine = $"ID: {publisher.Id} | {publisher.Name} | Държава: {publisher.Country}";

                    listBox2.Items.Add(displayLine);
                }
            
        }
    }
}
