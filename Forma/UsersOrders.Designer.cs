namespace Forma
{
    partial class UsersOrders
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
            listBox1 = new ListBox();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            button3 = new Button();
            button2 = new Button();
            tabPage2 = new TabPage();
            textBox1 = new TextBox();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button4 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(33, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(786, 472);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dateTimePicker2);
            tabPage1.Controls.Add(dateTimePicker1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(778, 439);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Филтрирай";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(62, 28);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(623, 224);
            listBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 304);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 6;
            label1.Text = "Дати за диапазон:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(276, 324);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(276, 278);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(587, 300);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "По дата";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(591, 381);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Всички";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Controls.Add(button1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(778, 439);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Детайли";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(224, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 40);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 3;
            label2.Text = "Поръчка ID:";
            label2.Click += label2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(81, 95);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(606, 281);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(299, 382);
            button1.Name = "button1";
            button1.Size = new Size(172, 29);
            button1.TabIndex = 1;
            button1.Text = "Детайли на поръчка";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(813, 507);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 1;
            button4.Text = "Назад";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // UsersOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 543);
            Controls.Add(button4);
            Controls.Add(tabControl1);
            Name = "UsersOrders";
            Text = "UsersOrders";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button3;
        private Button button2;
        private Button button4;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private ListBox listBox1;
        private TabPage tabPage2;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private RichTextBox richTextBox1;
    }
}