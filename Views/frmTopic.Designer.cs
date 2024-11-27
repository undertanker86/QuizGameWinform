namespace QuizGame.Views
{
    partial class frmTopic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopic));
            txtName = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvTopics = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTopics).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtName.Location = new Point(150, 133);
            txtName.Name = "txtName";
            txtName.Size = new Size(526, 31);
            txtName.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnSearch.Location = new Point(39, 198);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 39);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.YellowGreen;
            btnAdd.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnAdd.Location = new Point(209, 198);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(121, 39);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Moccasin;
            btnEdit.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnEdit.Location = new Point(386, 198);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(121, 39);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnDelete.Location = new Point(555, 198);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(121, 39);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvTopics
            // 
            dgvTopics.BackgroundColor = SystemColors.ButtonHighlight;
            dgvTopics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopics.Location = new Point(39, 275);
            dgvTopics.Name = "dgvTopics";
            dgvTopics.Size = new Size(637, 387);
            dgvTopics.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("AniMe Matrix - MB_EN", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(240, 30);
            label1.Name = "label1";
            label1.Size = new Size(257, 39);
            label1.TabIndex = 10;
            label1.Text = "EDIT TOPIC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label2.Location = new Point(33, 136);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 11;
            label2.Text = "Name:";
            // 
            // frmTopic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(712, 675);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvTopics);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnSearch);
            Controls.Add(txtName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmTopic";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ((System.ComponentModel.ISupportInitialize)dgvTopics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvTopics;
        private Label label1;
        private Label label2;
    }
}