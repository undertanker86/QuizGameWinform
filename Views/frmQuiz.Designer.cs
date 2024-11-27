namespace QuizGame.Views
{
    partial class frmQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuiz));
            lblQuestion = new Label();
            panelAnswers = new Panel();
            btnNext = new Button();
            lblResult = new Label();
            lblTimer = new Label();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            lblQuestion.Location = new Point(227, 102);
            lblQuestion.Margin = new Padding(4, 0, 4, 0);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(110, 43);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "label1";
            // 
            // panelAnswers
            // 
            panelAnswers.BackColor = SystemColors.ButtonFace;
            panelAnswers.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelAnswers.Location = new Point(227, 260);
            panelAnswers.Margin = new Padding(4, 5, 4, 5);
            panelAnswers.Name = "panelAnswers";
            panelAnswers.Size = new Size(1036, 653);
            panelAnswers.TabIndex = 1;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.IndianRed;
            btnNext.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnNext.Location = new Point(1291, 1012);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(210, 93);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            lblResult.Location = new Point(17, 1058);
            lblResult.Margin = new Padding(4, 0, 4, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(110, 43);
            lblResult.TabIndex = 3;
            lblResult.Text = "label1";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            lblTimer.Location = new Point(1211, 37);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(110, 43);
            lblTimer.TabIndex = 4;
            lblTimer.Text = "label1";
            // 
            // frmQuiz
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1519, 1127);
            Controls.Add(lblTimer);
            Controls.Add(lblResult);
            Controls.Add(btnNext);
            Controls.Add(panelAnswers);
            Controls.Add(lblQuestion);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmQuiz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private Panel panelAnswers;
        private Button btnNext;
        private Label lblResult;
        private Label lblTimer;
    }
}