namespace QuizGame.Views
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnRegister = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Location = new Point(31, 33);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1179, 772);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(587, 423);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(179, 43);
            label3.TabIndex = 12;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(587, 303);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 43);
            label2.TabIndex = 11;
            label2.Text = "Gmail:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(91, 263);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 274);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(183, 63);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(738, 55);
            label1.TabIndex = 9;
            label1.Text = "QUIZ GAME PROGRAM LOGIN";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.LightGoldenrodYellow;
            btnRegister.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnRegister.Location = new Point(904, 583);
            btnRegister.Margin = new Padding(4, 5, 4, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(174, 68);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.PeachPuff;
            btnLogin.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(666, 583);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(174, 68);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Sitka Small", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(776, 418);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(343, 43);
            txtPassword.TabIndex = 6;
            txtPassword.Text = "123";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Sitka Small", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(776, 298);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(343, 43);
            txtEmail.TabIndex = 5;
            txtEmail.Text = "admin@gmail.com";
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(645, 669);
            button1.Name = "button1";
            button1.Size = new Size(214, 34);
            button1.TabIndex = 13;
            button1.Text = "Forgot password?";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1249, 828);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnRegister;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button1;
    }
}