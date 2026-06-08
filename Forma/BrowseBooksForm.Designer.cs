namespace Forma
{
    partial class BrowseBooksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseBooksForm));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label2 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            groupBox1 = new GroupBox();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            listBox1 = new ListBox();
            button7 = new Button();
            button8 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(23, 8);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1315, 600);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(button7);
            tabPage1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1307, 564);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Филтрирай";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(250, 248, 244);
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(47, 43, 40);
            label2.Location = new Point(261, 131);
            label2.Name = "label2";
            label2.Size = new Size(20, 26);
            label2.TabIndex = 15;
            label2.Text = "-";
            label2.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(74, 52, 39);
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(250, 248, 244);
            button1.Location = new Point(178, 437);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(183, 67);
            button1.TabIndex = 14;
            button1.Text = "Приложи Филтрация";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click_1;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(250, 248, 244);
            textBox3.ForeColor = Color.FromArgb(47, 43, 40);
            textBox3.Location = new Point(306, 127);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(118, 30);
            textBox3.TabIndex = 13;
            textBox3.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton6);
            groupBox1.Controls.Add(radioButton5);
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = Color.FromArgb(250, 248, 244);
            groupBox1.Location = new Point(52, 185);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(499, 233);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Избери по какво да филтрираш:";
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.BackColor = Color.FromArgb(74, 52, 39);
            radioButton6.Location = new Point(271, 164);
            radioButton6.Margin = new Padding(4, 3, 4, 3);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(153, 27);
            radioButton6.TabIndex = 5;
            radioButton6.TabStop = true;
            radioButton6.Text = "В Наличност";
            radioButton6.UseVisualStyleBackColor = false;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.BackColor = Color.FromArgb(74, 52, 39);
            radioButton5.Location = new Point(271, 112);
            radioButton5.Margin = new Padding(4, 3, 4, 3);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(108, 27);
            radioButton5.TabIndex = 4;
            radioButton5.TabStop = true;
            radioButton5.Text = "По Цена";
            radioButton5.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.BackColor = Color.FromArgb(74, 52, 39);
            radioButton4.Location = new Point(272, 58);
            radioButton4.Margin = new Padding(4, 3, 4, 3);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(138, 27);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "По Заглавие";
            radioButton4.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.BackColor = Color.FromArgb(74, 52, 39);
            radioButton3.Location = new Point(36, 164);
            radioButton3.Margin = new Padding(4, 3, 4, 3);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(111, 27);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "По Жанр";
            radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.FromArgb(74, 52, 39);
            radioButton2.Location = new Point(32, 97);
            radioButton2.Margin = new Padding(4, 3, 4, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(185, 27);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "По Издателство";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.FromArgb(74, 52, 39);
            radioButton1.Location = new Point(32, 43);
            radioButton1.Margin = new Padding(4, 3, 4, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(120, 27);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "По Автор";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(250, 248, 244);
            textBox2.ForeColor = Color.FromArgb(47, 43, 40);
            textBox2.Location = new Point(123, 127);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(118, 30);
            textBox2.TabIndex = 11;
            textBox2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(74, 52, 39);
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(250, 248, 244);
            label1.Location = new Point(22, 64);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 10;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(250, 248, 244);
            textBox1.ForeColor = Color.FromArgb(47, 43, 40);
            textBox1.Location = new Point(261, 60);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 30);
            textBox1.TabIndex = 9;
            textBox1.Visible = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(250, 248, 244);
            numericUpDown1.ForeColor = Color.FromArgb(47, 43, 40);
            numericUpDown1.Location = new Point(722, 492);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 30);
            numericUpDown1.TabIndex = 8;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(250, 248, 244);
            listBox1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            listBox1.ForeColor = Color.FromArgb(47, 43, 40);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(601, 6);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(686, 445);
            listBox1.TabIndex = 7;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(250, 248, 244);
            button7.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.FromArgb(47, 43, 40);
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(945, 472);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new Size(167, 64);
            button7.TabIndex = 6;
            button7.Text = "Добави в количка";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(250, 248, 244);
            button8.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button8.ForeColor = Color.FromArgb(47, 43, 40);
            button8.Location = new Point(1285, 614);
            button8.Margin = new Padding(4, 3, 4, 3);
            button8.Name = "button8";
            button8.Size = new Size(88, 34);
            button8.TabIndex = 1;
            button8.Text = "Назад";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // BrowseBooksForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(74, 52, 39);
            ClientSize = new Size(1386, 660);
            Controls.Add(tabControl1);
            Controls.Add(button8);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "BrowseBooksForm";
            Text = "BrowseBooksForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button7;
        private Button button8;
        private ListBox listBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private TextBox textBox3;
        private Label label2;
    }
}