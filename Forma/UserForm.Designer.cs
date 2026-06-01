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
            tabControl1.Location = new Point(21, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(733, 460);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(725, 427);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Всички";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(582, 356);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 2;
            button4.Text = "Покажи";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(54, 98);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(378, 264);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 48);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
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
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(725, 427);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Филтрирай по роля";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(433, 70);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 5;
            label3.Text = "Потребители:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 70);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 4;
            label2.Text = "Администратори:";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(401, 124);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(293, 164);
            listBox3.TabIndex = 3;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(25, 124);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(285, 164);
            listBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(297, 342);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Покажи";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(listBox4);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(725, 427);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Изтрий потребител";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 60);
            label6.Name = "label6";
            label6.Size = new Size(155, 20);
            label6.TabIndex = 3;
            label6.Text = "Всички потребители:";
            // 
            // button2
            // 
            button2.Location = new Point(579, 355);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Изтрий";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 40);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 1;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.Location = new Point(52, 112);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(453, 264);
            listBox4.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button5);
            tabPage4.Controls.Add(textBox1);
            tabPage4.Controls.Add(label5);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(725, 427);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Направи админ";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(292, 314);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 2;
            button5.Text = "Направи админ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(394, 113);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 113);
            label5.Name = "label5";
            label5.Size = new Size(184, 20);
            label5.TabIndex = 0;
            label5.Text = "Username на потребител:";
            // 
            // button3
            // 
            button3.Location = new Point(760, 457);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 1;
            button3.Text = "Назад";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 498);
            Controls.Add(button3);
            Controls.Add(tabControl1);
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
    }
}