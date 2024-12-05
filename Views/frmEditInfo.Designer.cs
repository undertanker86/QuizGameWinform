namespace QuizGame.Views
{
    partial class frmEditInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditInfo));
            txtFullName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            cmbGender = new ComboBox();
            txtEmail = new TextBox();
            btnSave = new Button();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtFullName.Location = new Point(1027, 242);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(510, 43);
            txtFullName.TabIndex = 0;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            dtpDateOfBirth.Location = new Point(1027, 383);
            dtpDateOfBirth.Margin = new Padding(4, 5, 4, 5);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(510, 43);
            dtpDateOfBirth.TabIndex = 1;
            // 
            // cmbGender
            // 
            cmbGender.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(1027, 528);
            cmbGender.Margin = new Padding(4, 5, 4, 5);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(510, 51);
            cmbGender.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtEmail.Location = new Point(1027, 674);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(510, 43);
            txtEmail.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Wheat;
            btnSave.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnSave.Location = new Point(901, 894);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 90);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(113, 242);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(593, 657);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            button1.Location = new Point(1337, 894);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(200, 90);
            button1.TabIndex = 6;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(516, 80);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(585, 55);
            label1.TabIndex = 10;
            label1.Text = "EDIT MY INFORMATION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label2.Location = new Point(756, 247);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(185, 43);
            label2.TabIndex = 11;
            label2.Text = "Full name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label3.Location = new Point(756, 388);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(235, 43);
            label3.TabIndex = 12;
            label3.Text = "Date Of Birth:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label4.Location = new Point(756, 542);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(141, 43);
            label4.TabIndex = 13;
            label4.Text = "Gender:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label5.Location = new Point(756, 665);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(101, 43);
            label5.TabIndex = 14;
            label5.Text = "Mail:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label6.Location = new Point(756, 775);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(179, 43);
            label6.TabIndex = 15;
            label6.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtPassword.Location = new Point(1027, 775);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(510, 43);
            txtPassword.TabIndex = 16;
            // 
            // frmEditInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1661, 1035);
            Controls.Add(txtPassword);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(cmbGender);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtFullName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmEditInfo";
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
        private Button btnSave;
        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtPassword;
    }
}