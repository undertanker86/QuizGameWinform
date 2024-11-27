namespace QuizGame.Views
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            txtFullName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            cbxGender = new ComboBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            dgvUsers = new DataGridView();
            btnRefesh = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBoxRole = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtFullName.Location = new Point(307, 118);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(560, 43);
            txtFullName.TabIndex = 0;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            dtpDateOfBirth.Location = new Point(1186, 116);
            dtpDateOfBirth.Margin = new Padding(4, 5, 4, 5);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(548, 43);
            dtpDateOfBirth.TabIndex = 4;
            // 
            // cbxGender
            // 
            cbxGender.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            cbxGender.FormattingEnabled = true;
            cbxGender.Location = new Point(1186, 232);
            cbxGender.Margin = new Padding(4, 5, 4, 5);
            cbxGender.Name = "cbxGender";
            cbxGender.Size = new Size(324, 51);
            cbxGender.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtEmail.Location = new Point(307, 232);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(560, 43);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            txtPassword.Location = new Point(307, 330);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(560, 43);
            txtPassword.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.BlanchedAlmond;
            btnAdd.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnAdd.Location = new Point(254, 446);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(184, 80);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Turquoise;
            btnEdit.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnEdit.Location = new Point(610, 446);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(184, 80);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnDelete.Location = new Point(947, 446);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(184, 80);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightGoldenrodYellow;
            btnSearch.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnSearch.Location = new Point(1266, 446);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(184, 80);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.ControlLightLight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(32, 563);
            dgvUsers.Margin = new Padding(4, 5, 4, 5);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1815, 558);
            dgvUsers.TabIndex = 9;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // btnRefesh
            // 
            btnRefesh.BackColor = Color.LightCyan;
            btnRefesh.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            btnRefesh.Location = new Point(1550, 446);
            btnRefesh.Margin = new Padding(4, 5, 4, 5);
            btnRefesh.Name = "btnRefesh";
            btnRefesh.Size = new Size(184, 80);
            btnRefesh.TabIndex = 10;
            btnRefesh.Text = "Refresh";
            btnRefesh.UseVisualStyleBackColor = false;
            btnRefesh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label1.Location = new Point(81, 118);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(188, 43);
            label1.TabIndex = 11;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label2.Location = new Point(81, 232);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 43);
            label2.TabIndex = 12;
            label2.Text = "Mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label3.Location = new Point(81, 330);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(179, 43);
            label3.TabIndex = 13;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label4.Location = new Point(930, 118);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(229, 43);
            label4.TabIndex = 14;
            label4.Text = "Date of birth:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label5.Location = new Point(947, 232);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(141, 43);
            label5.TabIndex = 15;
            label5.Text = "Gender:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(629, 34);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(530, 55);
            label6.TabIndex = 16;
            label6.Text = "USER MANAGEMENT";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label7.Location = new Point(947, 330);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(99, 43);
            label7.TabIndex = 18;
            label7.Text = "Role:";
            // 
            // comboBoxRole
            // 
            comboBoxRole.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(1186, 322);
            comboBoxRole.Margin = new Padding(4, 5, 4, 5);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(324, 51);
            comboBoxRole.TabIndex = 17;
            // 
            // frmUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1898, 1160);
            Controls.Add(label7);
            Controls.Add(comboBoxRole);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRefesh);
            Controls.Add(dgvUsers);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(cbxGender);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtFullName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullName;
        private DateTimePicker dtpDateOfBirth;
        private ComboBox cbxGender;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private DataGridView dgvUsers;
        private Button btnRefesh;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboBoxRole;
    }
}