namespace Forma
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            label3 = new Label();
            label2 = new Label();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            button1 = new Button();
            tabPage3 = new TabPage();
            button6 = new Button();
            label6 = new Label();
            button2 = new Button();
            label4 = new Label();
            listBox4 = new ListBox();
            button3 = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(35, 8);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1099, 505);
            tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackgroundImage = (Image)resources.GetObject("tabPage2.BackgroundImage");
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(listBox3);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(button1);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(1091, 469);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Филтрирай по роля";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(245, 235, 224);
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.FromArgb(53, 34, 8);
            label3.Location = new Point(576, 51);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(166, 26);
            label3.TabIndex = 5;
            label3.Text = "Потребители:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(245, 235, 224);
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(53, 34, 8);
            label2.Location = new Point(34, 51);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(208, 26);
            label2.TabIndex = 4;
            label2.Text = "Администратори:";
            // 
            // listBox3
            // 
            listBox3.BackColor = Color.FromArgb(245, 235, 224);
            listBox3.ForeColor = Color.FromArgb(53, 34, 8);
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 23;
            listBox3.Location = new Point(576, 102);
            listBox3.Margin = new Padding(4, 3, 4, 3);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(461, 234);
            listBox3.TabIndex = 3;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.FromArgb(245, 235, 224);
            listBox2.ForeColor = Color.FromArgb(53, 34, 8);
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 23;
            listBox2.Location = new Point(34, 102);
            listBox2.Margin = new Padding(4, 3, 4, 3);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(447, 234);
            listBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 235, 224);
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.FromArgb(53, 34, 8);
            button1.Location = new Point(457, 405);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(134, 44);
            button1.TabIndex = 0;
            button1.Text = "Покажи";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackgroundImage = (Image)resources.GetObject("tabPage3.BackgroundImage");
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(listBox4);
            tabPage3.Location = new Point(4, 32);
            tabPage3.Margin = new Padding(4, 3, 4, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(4, 3, 4, 3);
            tabPage3.Size = new Size(1091, 469);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Изтрий потребител";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(245, 235, 224);
            button6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button6.ForeColor = Color.FromArgb(53, 34, 8);
            button6.Location = new Point(809, 303);
            button6.Name = "button6";
            button6.Size = new Size(129, 47);
            button6.TabIndex = 4;
            button6.Text = "Покажи";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(245, 235, 224);
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.FromArgb(53, 34, 8);
            label6.Location = new Point(27, 29);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(241, 26);
            label6.TabIndex = 3;
            label6.Text = "Всички потребители:";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(53, 34, 8);
            button2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.FromArgb(245, 235, 224);
            button2.Location = new Point(809, 374);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(129, 47);
            button2.TabIndex = 2;
            button2.Text = "Изтрий";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 46);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 23);
            label4.TabIndex = 1;
            // 
            // listBox4
            // 
            listBox4.BackColor = Color.FromArgb(245, 235, 224);
            listBox4.ForeColor = Color.FromArgb(53, 34, 8);
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 23;
            listBox4.Location = new Point(27, 72);
            listBox4.Margin = new Padding(4, 3, 4, 3);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(724, 349);
            listBox4.TabIndex = 0;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(245, 235, 224);
            button3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button3.ForeColor = Color.FromArgb(53, 34, 8);
            button3.Location = new Point(1049, 519);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(129, 42);
            button3.TabIndex = 1;
            button3.Text = "Назад";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 34, 8);
            ClientSize = new Size(1191, 573);
            Controls.Add(button3);
            Controls.Add(tabControl1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserForm";
            Text = "UserForm";
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage2;
        private Button button1;
        private TabPage tabPage3;
        private Button button3;
        private ListBox listBox3;
        private ListBox listBox2;
        private Label label3;
        private Label label2;
        private Button button2;
        private Label label4;
        private ListBox listBox4;
        private Label label6;
        private Button button6;
    }
}