namespace QuizGame.Views
{
    partial class frmResetPassword
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
            txtNewPassword = new TextBox();
            btn_newPassword = new Button();
            txtConfirmPassword = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 164);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 0;
            label1.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(245, 161);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(284, 31);
            txtNewPassword.TabIndex = 1;
            // 
            // btn_newPassword
            // 
            btn_newPassword.Location = new Point(245, 300);
            btn_newPassword.Name = "btn_newPassword";
            btn_newPassword.Size = new Size(134, 70);
            btn_newPassword.TabIndex = 2;
            btn_newPassword.Text = "Enter";
            btn_newPassword.UseVisualStyleBackColor = true;
            btn_newPassword.Click += btn_newPassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(245, 226);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(284, 31);
            txtConfirmPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 229);
            label2.Name = "label2";
            label2.Size = new Size(160, 25);
            label2.TabIndex = 4;
            label2.Text = "Confirm Password:";
            label2.Click += label2_Click;
            // 
            // frmResetPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btn_newPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(label1);
            Name = "frmResetPassword";
            Text = "frmResetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNewPassword;
        private Button btn_newPassword;
        private TextBox txtConfirmPassword;
        private Label label2;
    }
}