namespace Forma
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(67, 40, 24);
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(245, 235, 224);
            label1.Location = new Point(254, 227);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(273, 32);
            label1.TabIndex = 0;
            label1.Text = "Потребителско име:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(67, 40, 24);
            label2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(245, 235, 224);
            label2.Location = new Point(254, 275);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 32);
            label2.TabIndex = 1;
            label2.Text = "Парола:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(245, 235, 224);
            textBox1.ForeColor = Color.FromArgb(67, 40, 24);
            textBox1.Location = new Point(544, 232);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(293, 30);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(245, 235, 224);
            textBox2.ForeColor = Color.FromArgb(67, 40, 24);
            textBox2.Location = new Point(393, 280);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(245, 30);
            textBox2.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(67, 40, 24);
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.FromArgb(245, 235, 224);
            button1.Location = new Point(376, 370);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(160, 48);
            button1.TabIndex = 0;
            button1.Text = "Вход";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(245, 235, 224);
            button2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.FromArgb(67, 40, 24);
            button2.Location = new Point(636, 370);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(160, 48);
            button2.TabIndex = 0;
            button2.Text = "Регистрация";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_ClickAsync;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(67, 40, 24);
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.FromArgb(245, 235, 224);
            label3.Location = new Point(483, 175);
            label3.Name = "label3";
            label3.Size = new Size(212, 34);
            label3.TabIndex = 3;
            label3.Text = "Начално меню";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1124, 573);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label3;
    }
}
