namespace QuizGame.Views
{
    partial class frmEditQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditQuiz));
            comboBoxTopicName = new ComboBox();
            panelQuestions = new Panel();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBoxTopicName
            // 
            comboBoxTopicName.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            comboBoxTopicName.FormattingEnabled = true;
            comboBoxTopicName.Location = new Point(563, 230);
            comboBoxTopicName.Margin = new Padding(4, 5, 4, 5);
            comboBoxTopicName.Name = "comboBoxTopicName";
            comboBoxTopicName.Size = new Size(884, 51);
            comboBoxTopicName.TabIndex = 6;
            // 
            // panelQuestions
            // 
            panelQuestions.BackColor = SystemColors.ButtonHighlight;
            panelQuestions.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            panelQuestions.Location = new Point(81, 365);
            panelQuestions.Margin = new Padding(4, 5, 4, 5);
            panelQuestions.Name = "panelQuestions";
            panelQuestions.Size = new Size(1756, 521);
            panelQuestions.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label1.Location = new Point(306, 235);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(235, 43);
            label1.TabIndex = 8;
            label1.Text = "Select a topic:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(650, 63);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(269, 55);
            label2.TabIndex = 11;
            label2.Text = "EDIT QUIZ";
            // 
            // frmEditQuiz
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1866, 975);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelQuestions);
            Controls.Add(comboBoxTopicName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmEditQuiz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTopicName;
        private Panel panelQuestions;
        private Label label1;
        private Label label2;
    }
}