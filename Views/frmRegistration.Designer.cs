namespace QuizGame.Views
{
    partial class frmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistration));
            txtFullName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            cmbGender = new ComboBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtFullName.Location = new Point(628, 169);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(262, 31);
            txtFullName.TabIndex = 0;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            dtpDateOfBirth.Location = new Point(629, 234);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(261, 31);
            dtpDateOfBirth.TabIndex = 1;
            // 
            // cmbGender
            // 
            cmbGender.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(629, 288);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(261, 36);
            cmbGender.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtEmail.Location = new Point(628, 345);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(262, 31);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtPassword.Location = new Point(629, 407);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(261, 31);
            txtPassword.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.GreenYellow;
            btnRegister.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnRegister.Location = new Point(774, 486);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(116, 43);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Sub";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            button1.Location = new Point(478, 486);
            button1.Name = "button1";
            button1.Size = new Size(116, 43);
            button1.TabIndex = 6;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(43, 169);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(359, 274);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("AniMe Matrix - MB_EN", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 41);
            label1.Name = "label1";
            label1.Size = new Size(813, 78);
            label1.TabIndex = 11;
            label1.Text = "QUIZ GAME PROGRAM REGISTRATION\n\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label2.Location = new Point(439, 173);
            label2.Name = "label2";
            label2.Size = new Size(124, 28);
            label2.TabIndex = 13;
            label2.Text = "Full Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label3.Location = new Point(439, 237);
            label3.Name = "label3";
            label3.Size = new Size(155, 28);
            label3.TabIndex = 14;
            label3.Text = "Date Of Birth:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label4.Location = new Point(439, 296);
            label4.Name = "label4";
            label4.Size = new Size(93, 28);
            label4.TabIndex = 15;
            label4.Text = "Gender:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label5.Location = new Point(439, 348);
            label5.Name = "label5";
            label5.Size = new Size(79, 28);
            label5.TabIndex = 16;
            label5.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label6.Location = new Point(439, 410);
            label6.Name = "label6";
            label6.Size = new Size(117, 28);
            label6.TabIndex = 17;
            label6.Text = "Password:";
            // 
            // frmRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(947, 577);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(cmbGender);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtFullName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRegistration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullName;
        private DateTimePicker dtpDateOfBirth;
        private ComboBox cmbGender;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnRegister;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}