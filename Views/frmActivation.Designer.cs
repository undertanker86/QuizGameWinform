namespace QuizGame.Views
{
    partial class frmActivation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblActivationCode;
        private TextBox txtActivationCode;
        private Button btnActivate;
        private Button btnBack;
        private Label lblMessage;


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
            this.lblMessage = new Label();
            this.lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMessage.Location = new Point(30, 20);
            this.lblMessage.Size = new Size(400, 40);
            this.lblMessage.Text = "A verification email has been sent.";
            this.Controls.Add(this.lblMessage);


            this.lblActivationCode = new Label();
            this.txtActivationCode = new TextBox();
            this.btnActivate = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();
            // 
            // lblActivationCode
            // 
            this.lblActivationCode.AutoSize = true;
            this.lblActivationCode.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblActivationCode.Location = new Point(30, 30);
            this.lblActivationCode.Name = "lblActivationCode";
            this.lblActivationCode.Size = new Size(170, 25);
            this.lblActivationCode.TabIndex = 0;
            this.lblActivationCode.Text = "Activation Code:";
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtActivationCode.Location = new Point(30, 70);
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new Size(300, 29);
            this.txtActivationCode.TabIndex = 1;
            // 
            // btnActivate
            // 
            this.btnActivate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnActivate.Location = new Point(30, 120);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new Size(150, 40);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new EventHandler(this.btnActivate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnBack.Location = new Point(200, 120);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(150, 40);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);
            // 
            // frmActivation
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 200);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.txtActivationCode);
            this.Controls.Add(this.lblActivationCode);
            this.Name = "frmActivation";
            this.Text = "Account Activation";
            this.ResumeLayout(false);
            this.PerformLayout();
        }



        #endregion
    }
}