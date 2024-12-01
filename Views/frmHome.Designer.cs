namespace QuizGame.Views
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            panel1 = new Panel();
            txtHelloUser = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            btnEditInfo = new Button();
            btn_PlayQuiz = new Button();
            btnViewResult = new Button();
            label1 = new Label();
            lblRank = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AntiqueWhite;
            panel1.Controls.Add(txtHelloUser);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnEditInfo);
            panel1.Controls.Add(btn_PlayQuiz);
            panel1.Controls.Add(btnViewResult);
            panel1.Location = new Point(4, 2);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 1244);
            panel1.TabIndex = 5;
            // 
            // txtHelloUser
            // 
            txtHelloUser.AutoSize = true;
            txtHelloUser.Font = new Font("Sitka Small", 18F, FontStyle.Bold);
            txtHelloUser.Location = new Point(39, 540);
            txtHelloUser.Margin = new Padding(4, 0, 4, 0);
            txtHelloUser.Name = "txtHelloUser";
            txtHelloUser.Size = new Size(0, 53);
            txtHelloUser.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 5);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(431, 437);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.MistyRose;
            button1.Font = new Font("Sitka Small", 18F, FontStyle.Bold);
            button1.Location = new Point(1, 929);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(510, 64);
            button1.TabIndex = 9;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnEditInfo
            // 
            btnEditInfo.BackColor = Color.MistyRose;
            btnEditInfo.Font = new Font("Sitka Small", 18F, FontStyle.Bold);
            btnEditInfo.Location = new Point(0, 843);
            btnEditInfo.Margin = new Padding(4, 5, 4, 5);
            btnEditInfo.Name = "btnEditInfo";
            btnEditInfo.Size = new Size(510, 61);
            btnEditInfo.TabIndex = 8;
            btnEditInfo.Text = "Edit Info";
            btnEditInfo.UseVisualStyleBackColor = false;
            btnEditInfo.Click += btnEditInfo_Click;
            // 
            // btn_PlayQuiz
            // 
            btn_PlayQuiz.BackColor = Color.MistyRose;
            btn_PlayQuiz.Font = new Font("Sitka Small", 18F, FontStyle.Bold);
            btn_PlayQuiz.Location = new Point(1, 674);
            btn_PlayQuiz.Margin = new Padding(4, 5, 4, 5);
            btn_PlayQuiz.Name = "btn_PlayQuiz";
            btn_PlayQuiz.Size = new Size(507, 60);
            btn_PlayQuiz.TabIndex = 6;
            btn_PlayQuiz.Text = "Play Quiz";
            btn_PlayQuiz.UseVisualStyleBackColor = false;
            btn_PlayQuiz.Click += btn_PlayQuiz_Click;
            // 
            // btnViewResult
            // 
            btnViewResult.BackColor = Color.MistyRose;
            btnViewResult.Font = new Font("Sitka Small", 18F, FontStyle.Bold);
            btnViewResult.Location = new Point(1, 764);
            btnViewResult.Margin = new Padding(4, 5, 4, 5);
            btnViewResult.Name = "btnViewResult";
            btnViewResult.Size = new Size(510, 60);
            btnViewResult.TabIndex = 7;
            btnViewResult.Text = "View Result";
            btnViewResult.UseVisualStyleBackColor = false;
            btnViewResult.Click += btnViewResult_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1094, 47);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 55);
            label1.TabIndex = 11;
            label1.Text = "RANK";
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Font = new Font("Sitka Small", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRank.Location = new Point(1094, 189);
            lblRank.Margin = new Padding(4, 0, 4, 0);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(152, 48);
            lblRank.TabIndex = 12;
            lblRank.Text = "lblRank";
            lblRank.Click += lblRank_Click;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1878, 1105);
            Controls.Add(lblRank);
            Controls.Add(label1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            Load += frmHome_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button btnEditInfo;
        private Button btnViewResult;
        private Button btn_PlayQuiz;
        private Button button1;
        private PictureBox pictureBox1;
        private Label txtHelloUser;
        private Label label1;
        private Label lblRank;
    }
}