namespace QuizGame.Views
{
    partial class frmResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResult));
            dgvResults = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // dgvResults
            // 
            dgvResults.BackgroundColor = SystemColors.ButtonHighlight;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(88, 134);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(950, 406);
            dgvResults.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("AniMe Matrix - MB_EN", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(462, 37);
            label1.Name = "label1";
            label1.Size = new Size(191, 39);
            label1.TabIndex = 12;
            label1.Text = "RESULT";
            // 
            // frmResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1111, 583);
            Controls.Add(label1);
            Controls.Add(dgvResults);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmResult";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            Load += frmResult_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvResults;
        private Label label1;
    }
}