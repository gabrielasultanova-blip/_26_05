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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button4 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
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
            tabPage4 = new TabPage();
            button5 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            button3 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(35, 8);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1099, 505);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1091, 469);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Всички";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button4.Location = new Point(861, 369);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(129, 45);
            button4.TabIndex = 2;
            button4.Text = "Покажи";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 23;
            listBox1.Location = new Point(38, 88);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(749, 326);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(38, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(241, 26);
            label1.TabIndex = 0;
            label1.Text = "Всички потребители:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(listBox3);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(button1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(1091, 472);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Филтрирай по роля";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
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
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.Location = new Point(34, 51);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(208, 26);
            label2.TabIndex = 4;
            label2.Text = "Администратори:";
            // 
            // listBox3
            // 
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
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button1.Location = new Point(457, 405);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(134, 44);
            button1.TabIndex = 0;
            button1.Text = "Покажи";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage3
            // 
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
            button6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button6.Location = new Point(809, 303);
            button6.Name = "button6";
            button6.Size = new Size(129, 47);
            button6.TabIndex = 4;
            button6.Text = "Покажи";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label6.Location = new Point(27, 29);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(241, 26);
            label6.TabIndex = 3;
            label6.Text = "Всички потребители:";
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button2.Location = new Point(809, 374);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(129, 47);
            button2.TabIndex = 2;
            button2.Text = "Изтрий";
            button2.UseVisualStyleBackColor = true;
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
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 23;
            listBox4.Location = new Point(27, 72);
            listBox4.Margin = new Padding(4, 3, 4, 3);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(724, 349);
            listBox4.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button5);
            tabPage4.Controls.Add(textBox1);
            tabPage4.Controls.Add(label5);
            tabPage4.Location = new Point(4, 32);
            tabPage4.Margin = new Padding(4, 3, 4, 3);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(4, 3, 4, 3);
            tabPage4.Size = new Size(1091, 469);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Направи админ";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button5.Location = new Point(420, 274);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(181, 48);
            button5.TabIndex = 2;
            button5.Text = "Направи админ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(503, 134);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 30);
            textBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.Location = new Point(188, 134);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(281, 26);
            label5.TabIndex = 0;
            label5.Text = "Username на потребител:";
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button3.Location = new Point(1049, 519);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(129, 42);
            button3.TabIndex = 1;
            button3.Text = "Назад";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 573);
            Controls.Add(button3);
            Controls.Add(tabControl1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserForm";
            Text = "UserForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button button3;
        private Button button4;
        private ListBox listBox1;
        private Label label1;
        private ListBox listBox3;
        private ListBox listBox2;
        private Label label3;
        private Label label2;
        private Button button2;
        private Label label4;
        private ListBox listBox4;
        private Label label6;
        private Button button5;
        private TextBox textBox1;
        private Label label5;
        private Button button6;
    }
}