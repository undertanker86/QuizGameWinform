namespace QuizGame.Views
{
    partial class frmCreateQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateQuiz));
            btnCreateQuiz = new Button();
            txtSoluong = new TextBox();
            btnSave = new Button();
            comboBoxTopicName = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            panelQuestions = new Panel();
            SuspendLayout();
            // 
            // btnCreateQuiz
            // 
            btnCreateQuiz.BackColor = Color.NavajoWhite;
            btnCreateQuiz.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnCreateQuiz.Image = (Image)resources.GetObject("btnCreateQuiz.Image");
            btnCreateQuiz.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreateQuiz.Location = new Point(1653, 20);
            btnCreateQuiz.Margin = new Padding(4, 5, 4, 5);
            btnCreateQuiz.Name = "btnCreateQuiz";
            btnCreateQuiz.Size = new Size(160, 73);
            btnCreateQuiz.TabIndex = 0;
            btnCreateQuiz.Text = "Create Quiz";
            btnCreateQuiz.UseVisualStyleBackColor = false;
            btnCreateQuiz.Click += btnCreateQuiz_Click;
            // 
            // txtSoluong
            // 
            txtSoluong.Font = new Font("Sitka Small", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSoluong.Location = new Point(1291, 88);
            txtSoluong.Margin = new Padding(4, 5, 4, 5);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.Size = new Size(208, 47);
            txtSoluong.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnSave.Location = new Point(1653, 128);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 73);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // comboBoxTopicName
            // 
            comboBoxTopicName.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxTopicName.FormattingEnabled = true;
            comboBoxTopicName.Location = new Point(256, 93);
            comboBoxTopicName.Margin = new Padding(4, 5, 4, 5);
            comboBoxTopicName.Name = "comboBoxTopicName";
            comboBoxTopicName.Size = new Size(623, 51);
            comboBoxTopicName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label1.Location = new Point(66, 92);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(172, 43);
            label1.TabIndex = 6;
            label1.Text = "Topic list:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label2.Location = new Point(915, 88);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(354, 43);
            label2.TabIndex = 7;
            label2.Text = "Number of questions:";
            // 
            // panelQuestions
            // 
            panelQuestions.AutoScroll = true;
            panelQuestions.BackColor = SystemColors.ButtonHighlight;
            panelQuestions.Location = new Point(66, 208);
            panelQuestions.Name = "panelQuestions";
            panelQuestions.Size = new Size(1465, 710);
            panelQuestions.TabIndex = 8;
            // 
            // frmCreateQuiz
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1898, 1160);
            Controls.Add(panelQuestions);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxTopicName);
            Controls.Add(btnSave);
            Controls.Add(txtSoluong);
            Controls.Add(btnCreateQuiz);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmCreateQuiz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateQuiz;
        private TextBox txtSoluong;
        private Button btnSave;
        private ComboBox comboBoxTopicName;
        private Label label1;
        private Label label2;
        private Panel panelQuestions;
    }
}