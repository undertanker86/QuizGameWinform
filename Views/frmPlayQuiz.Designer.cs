namespace QuizGame.Views
{
    partial class frmPlayQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayQuiz));
            comboBoxTopics = new ComboBox();
            btnStartQuiz = new Button();
            label1 = new Label();
            txtRules = new Label();
            SuspendLayout();
            // 
            // comboBoxTopics
            // 
            comboBoxTopics.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            comboBoxTopics.FormattingEnabled = true;
            comboBoxTopics.Location = new Point(379, 77);
            comboBoxTopics.Margin = new Padding(4, 5, 4, 5);
            comboBoxTopics.Name = "comboBoxTopics";
            comboBoxTopics.Size = new Size(801, 51);
            comboBoxTopics.TabIndex = 0;
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnStartQuiz.Location = new Point(1244, 72);
            btnStartQuiz.Margin = new Padding(4, 5, 4, 5);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(181, 65);
            btnStartQuiz.TabIndex = 1;
            btnStartQuiz.Text = "Play";
            btnStartQuiz.UseVisualStyleBackColor = true;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label1.Location = new Point(156, 90);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(208, 43);
            label1.TabIndex = 2;
            label1.Text = "Select topic:";
            // 
            // txtRules
            // 
            txtRules.AutoSize = true;
            txtRules.Font = new Font("Sitka Small", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRules.Location = new Point(156, 225);
            txtRules.Margin = new Padding(4, 0, 4, 0);
            txtRules.Name = "txtRules";
            txtRules.Size = new Size(85, 34);
            txtRules.TabIndex = 3;
            txtRules.Text = "label2";
            // 
            // frmPlayQuiz
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1702, 1003);
            Controls.Add(txtRules);
            Controls.Add(label1);
            Controls.Add(btnStartQuiz);
            Controls.Add(comboBoxTopics);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmPlayQuiz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTopics;
        private Button btnStartQuiz;
        private Label label1;
        private Label txtRules;
    }
}