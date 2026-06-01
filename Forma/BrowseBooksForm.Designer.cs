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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button8 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(113, 39);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(477, 356);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button7);
            tabPage1.Controls.Add(button6);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(469, 323);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Филтрирай";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(318, 199);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 6;
            button7.Text = "Добави в количка";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(301, 69);
            button6.Name = "button6";
            button6.Size = new Size(121, 29);
            button6.TabIndex = 5;
            button6.Text = "В наличност";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(64, 265);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 4;
            button5.Text = "По Цена";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(36, 196);
            button4.Name = "button4";
            button4.Size = new Size(122, 29);
            button4.TabIndex = 3;
            button4.Text = "По Заглавие";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(50, 161);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "По Жанр";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(60, 111);
            button2.Name = "button2";
            button2.Size = new Size(139, 29);
            button2.TabIndex = 1;
            button2.Text = "По Издателство";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(43, 66);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "По Автор";
            button1.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(648, 339);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 1;
            button8.Text = "Назад";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // BrowseBooksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button8);
            Controls.Add(tabControl1);
            Name = "BrowseBooksForm";
            Text = "BrowseBooksForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button2;
        private Button button1;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button8;
    }
}