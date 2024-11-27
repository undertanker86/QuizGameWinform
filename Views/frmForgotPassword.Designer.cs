namespace QuizGame.Views
{
    partial class frmForgotPassword
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
            label1 = new Label();
            label2 = new Label();
            text_resetPassword = new TextBox();
            btn_resetpassword = new Button();
            btn_back = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 190);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 0;
            label1.Text = "Email (Reset Password)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 106);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 1;
            // 
            // text_resetPassword
            // 
            text_resetPassword.Location = new Point(283, 190);
            text_resetPassword.Name = "text_resetPassword";
            text_resetPassword.Size = new Size(291, 31);
            text_resetPassword.TabIndex = 2;
            // 
            // btn_resetpassword
            // 
            btn_resetpassword.Location = new Point(283, 257);
            btn_resetpassword.Name = "btn_resetpassword";
            btn_resetpassword.Size = new Size(112, 31);
            btn_resetpassword.TabIndex = 3;
            btn_resetpassword.Text = "Enter";
            btn_resetpassword.UseVisualStyleBackColor = true;
            btn_resetpassword.Click += btn_resetpassword_Click;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(462, 257);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(112, 31);
            btn_back.TabIndex = 4;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // frmForgotPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_back);
            Controls.Add(btn_resetpassword);
            Controls.Add(text_resetPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmForgotPassword";
            Text = "frmForgotPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox text_resetPassword;
        private Button btn_resetpassword;
        private Button btn_back;
    }
}